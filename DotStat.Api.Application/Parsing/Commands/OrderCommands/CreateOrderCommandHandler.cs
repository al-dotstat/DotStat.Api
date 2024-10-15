using DotStat.Api.Application.Common.Interfaces.Export;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Commands.OrderCommands;

public class CreateOrderCommandHandler(
  IOrderRepository orderRepository,
  IUserRepository userRepository,
  IComplexRepository complexRepository,
  IFlatRepository flatRepository,
  IParkingRepository parkingRepository,
  IStorageRepository storageRepository,
  ICommercialRepository commercialRepository,
  IExporter exporter,
  ILocalStorageService localStorageService
) : IRequestHandler<CreateOrderCommand, ErrorOr<OrderResult>>
{
  public async Task<ErrorOr<OrderResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    if (!await userRepository.ExistAsync(request.UserId))
      return Errors.User.UnknownUser;

    var complexes = new Dictionary<ComplexId, Complex>();
    foreach (var orderItem in request.Items)
    {
      if (await complexRepository.GetByIdAsync(orderItem.ComplexId) is not Complex complex)
        return Errors.Complex.UnknownComplex;
      complexes.Add(orderItem.ComplexId, complex);
    }

    var files = new List<(byte[] Body, string Name)>();
    foreach (var orderItem in request.Items)
    {
      var flats = orderItem.IncludeFlats ? await flatRepository.GetComplexFlatsAsync(orderItem.ComplexId) : [];
      var parkings = orderItem.IncludeParkings ? await parkingRepository.GetComplexParkingsAsync(orderItem.ComplexId) : [];
      var storages = orderItem.IncludeStorages ? await storageRepository.GetComplexStoragesAsync(orderItem.ComplexId) : [];
      var commercials = orderItem.IncludeCommercials ? await commercialRepository.GetComplexCommercialsAsync(orderItem.ComplexId) : [];

      var complexName = complexes[orderItem.ComplexId].NameRu;
      var fileName = complexName + ".xlsx";
      var file = exporter.Export(
        complexName,
        flats,
        storages,
        parkings,
        commercials
      );
      files.Add((file, fileName));
    }

    var zipName = Guid.NewGuid().ToString() + ".zip";
    var zipPath = Path.Combine(localStorageService.GetStoragePath(), zipName);
    exporter.ExportToZip(zipPath, files);

    var orderItems = request.Items.Select(item => OrderItem.Create(
      item.ComplexId,
      item.IncludeFlats,
      item.IncludeParkings,
      item.IncludeStorages,
      item.IncludeCommercials));

    var order = Order.Create(
      request.UserId,
      zipName,
      DateTime.UtcNow.AddDays(3),
      orderItems
    );

    await orderRepository.AddAsync(order);
    await orderRepository.SaveChangesAsync();

    return new OrderResult(order);
  }
}
