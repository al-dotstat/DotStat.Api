using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.Common.Enums;
using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.FlatAggregate.Entities;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.ParkingAggregate.Entities;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.StorageAggregate;
using DotStat.Api.Domain.StorageAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Fake;

public class FakeCommandHandler(
  IDeveloperRepository developerRepository,
  IComplexRepository complexRepository,
  IDistrictRepository districtRepository,
  IBuildingRepository buildingRepository,
  IFlatRepository flatRepository,
  IParkingRepository parkingRepository,
  IStorageRepository storageRepository,
  IParseRepository parseRepository
) : IRequestHandler<FakeCommand, ErrorOr<bool>>
{
  public async Task<ErrorOr<bool>> Handle(FakeCommand request, CancellationToken cancellationToken)
  {
    // if ((await developerRepository.GetAllAsync()).Count != 0)
    //   return Error.Conflict("AlreadyGenerated", "В базе данных уже есть информация");

    var random = new Random();

    var newDevelopers = (await developerRepository.GetAllAsync()).ToArray();
    if (newDevelopers.Length == 0)
    {
      newDevelopers = new Developer[]
      {
      Developer.Create("LSR", "ЛСР", "/images/lsr.svg"),
      Developer.Create("TEN", "ТЕН", "/images/ten.jpeg"),
      Developer.Create("Baza", "База", "/images/baza.svg"),
      };
      developerRepository.AddRange(newDevelopers);
      developerRepository.SaveChanges();
    }

    var districts = (await districtRepository.GetAllAsync()).ToArray();
    if (districts.Length == 0)
    {
      districts = new District[]
      {
      District.Create("Железнодорожный"),
      District.Create("Кировский"),
      };
      districtRepository.AddRange(districts);
      districtRepository.SaveChanges();
    }

    var newComplexes = (await complexRepository.GetAllComplexesAsync()).ToArray();
    if (newComplexes.Length == 0)
    {
      newComplexes = new Complex[]
      {
      Complex.Create("Zolotoy", "Золотой", "Современный жилой комплекс, расположенный в экологически чистом районе города. Комплекс включает несколько домов с закрытой территорией и подземным паркингом.", "ул. Малышева, 145", "56.8346", "60.5997", 72000, "/images/zhk1.jpeg", DateTime.Parse("2023-12-01"), districts[0].Id),
      Complex.Create("Tatishchev", "Татищев", "Уютный жилой комплекс в исторической части города. Предлагает разнообразие планировок и развитую инфраструктуру.", "ул. Татищева, 90", "56.8353", "60.5726", 45000, "/images/zhk2.jpg", DateTime.Parse("2022-10-01"), districts[0].Id),
      Complex.Create("Akvamarin", "Аквамарин", "Элитный жилой комплекс с видом на реку Исеть. Комплекс оборудован фитнес-залом, бассейном и закрытой территорией.", "ул. Щорса, 102", "56.8129", "60.5884", 64000, "/images/zhk3.jpeg", DateTime.Parse("2024-06-01"), districts[1].Id),
      Complex.Create("Vysokiy bereg", "Высокий берег", "Многоэтажный комплекс с прекрасными видами на город. В шаговой доступности парки, школы и магазины.", "ул. Сулимова, 5", "56.8585", "60.6087", 54000, "/images/zhk4.jpg", DateTime.Parse("2025-03-01"), districts[0].Id),
      Complex.Create("Yubileynyy", "Юбилейный", "Жилой комплекс в центре города с отличной транспортной доступностью. Включает детские площадки и зону отдыха.", "ул. Ленина, 25", "56.8430", "60.6123", 35000, "/images/zhk5.jpg", DateTime.Parse("2023-08-01"), districts[1].Id),
      Complex.Create("Zelenyy bor", "Зеленый бор", "Комплекс, окруженный зеленью и соснами. Отличный выбор для тех, кто ценит тишину и спокойствие.", "ул. Репина, 12", "56.8189", "60.5556", 47000, "/images/zhk6.jpeg", DateTime.Parse("2022-09-01"), districts[1].Id),
      Complex.Create("Bliznetsy", "Близнецы", "Два современных многоэтажных дома с закрытой территорией и детскими площадками. Хорошее транспортное сообщение.", "ул. Радищева, 3", "56.8361", "60.6100", 59000, "/images/zhk7.jpg", DateTime.Parse("2024-11-01"), districts[1].Id),
      Complex.Create("Izumrudnyy", "Изумрудный", "Комфорт-класс комплекс с квартирами улучшенной планировки и парковкой. Рядом торговый центр и метро.", "ул. Шейнкмана, 24", "56.8366", "60.6058", 62000, "/images/zhk8.jpg", DateTime.Parse("2023-04-01"), districts[0].Id),
      Complex.Create("Svetlyy mir", "Светлый мир", "Один из самых ярких проектов города. Жилой комплекс с просторными квартирами и панорамными окнами.", "ул. Волгоградская, 30", "56.8111", "60.6309", 68000, "/images/zhk9.jpg", DateTime.Parse("2023-07-01"), districts[0].Id),
      Complex.Create("Panorama", "Панорама", "Современный жилой комплекс с прекрасными видами на город. В комплексе предусмотрены коммерческие помещения.", "ул. Пальмиро Тольятти, 15", "56.8218", "60.6083", 54000, "/images/zhk10.webp", DateTime.Parse("2024-09-01"), districts[1].Id),
      Complex.Create("Kristall", "Кристалл", "Высококачественный жилой комплекс с дизайнерскими интерьерами и закрытой территорией.", "ул. Щорса, 50", "56.8104", "60.5857", 73000, "/images/zhk11.jpg", DateTime.Parse("2023-05-01"), districts[0].Id),
      Complex.Create("Solnechnyy", "Солнечный", "Комплекс в динамично развивающемся районе. На территории предусмотрены магазины, аптеки и зоны отдыха.", "ул. Щорса, 101", "56.8166", "60.6045", 49000, "/images/zhk12.jpg", DateTime.Parse("2025-01-01"), districts[1].Id),
      Complex.Create("Vershina", "Вершина", "Жилой комплекс премиум-класса с потрясающими видами на город. Подземная парковка и развитая инфраструктура.", "ул. Луначарского, 48", "56.8358", "60.6027", 85000, "/images/zhk13.jpg", DateTime.Parse("2023-10-01"), districts[1].Id),
      Complex.Create("Sapphire", "Сапфир", "Ультрасовременный жилой комплекс с квартирами различных планировок и панорамными окнами. Подземная парковка.", "ул. Краснолесья, 123", "56.8321", "60.5904", 61000, "/images/zhk14.jpg", DateTime.Parse("2024-03-01"), districts[0].Id),
      Complex.Create("Severnoe siyaniye", "Северное сияние", "Жилой комплекс с квартирами бизнес-класса. На территории предусмотрены зоны отдыха и подземная парковка.", "ул. Академика Шварца, 31", "56.8329", "60.6261", 74000, "/images/zhk15.jpg", DateTime.Parse("2024-10-01"), districts[0].Id),
      };
      complexRepository.AddRange(newComplexes);
      complexRepository.SaveChanges();
    }

    foreach (var complex in newComplexes)
    {
      var developerId = newDevelopers[random.Next(2)].Id;
      if (!complex.Developers.Any())
      {
        var complexDeveloper = ComplexDeveloper.Create(developerId);
        complex.SetDevelopers([complexDeveloper]);
      }

      var buildings = (await buildingRepository.GetComplexBuildingsAsync(complex.Id)).ToArray();
      if (buildings.Length == 0)
      {
        var buildingNumbers = Enumerable.Range(0, random.Next(1, 4));
        buildings = buildingNumbers.Select(i => Building.Create($"Дом {i}", complex.Id)).ToArray();
        buildingRepository.AddRange(buildings);
        buildingRepository.SaveChanges();
      }

      var areParkingsParsing = random.Next(2) == 1;
      var areStoragesParsing = random.Next(2) == 1;
      var parseCount = random.Next(2, 7);
      var parsings = (await parseRepository.GetComplexParsesAsync(complex.Id)).ToArray();
      if (parsings.Length == 0)
      {
        parsings = Enumerable.Range(0, parseCount).Select(i => Parse.Create(
          new DateTime(2024, 10 - i, random.Next(1, 28)),
          complex.Id,
          true,
          areParkingsParsing,
          areStoragesParsing,
          false)).ToArray();
        parseRepository.AddRange(parsings);
        parseRepository.SaveChanges();
      }
      else
      {
        areParkingsParsing = parsings.First().AreParkingsParsed;
        areStoragesParsing = parsings.First().AreStoragesParsed;
      }

      foreach (var building in buildings)
      {
        var flats = (await flatRepository.GetBuildingFlatsAsync(building.Id)).ToArray();
        if (flats.Length == 0)
        {
          var flatNumbers = Enumerable.Range(0, random.Next(15, 100));
          flats = flatNumbers.Select(i => Flat.Create(
            $"Квартира {i}",
            null,
            building.Id,
            developerId,
            null,
            random.Next(2) == 1,
            i.ToString(),
            null,
            (Status)random.Next(3))).ToArray();
          flatRepository.AddRange(flats);
          flatRepository.SaveChanges();
        }

        var flatCountFlag = 1;
        foreach (var flat in flats)
        {
          if (flat.ParsingInfos.Count > 0) break;
          var number = flatCountFlag;
          var roominess = random.Next(0, 4);
          var floor = random.Next(1, 30);
          var area = random.Next(25, 150) + random.NextDouble();
          var basePrice = random.Next(3000000, 20000000);
          var soldParse = flat.CurrentStatus == Status.Sold ? parsings.ToArray()[random.Next(parsings.Count())] : null;
          foreach (var parse in parsings)
          {
            var status = soldParse is not null && parse.Id.Value == soldParse.Id.Value ? Status.Sold : random.Next(2) == 1 ? Status.Available : Status.Booked;
            var flatParsingInfo = FlatParsingInfo.Create(
              parse.Id,
              number.ToString(),
              roominess == 0 ? "Студия" : roominess.ToString(),
              floor.ToString(),
              area,
              null,
              building.Name,
              null,
              basePrice + (random.Next(2) == 1 ? 1 : -1) * random.Next(2000000),
              parse.Date,
              status
            );

            flat.AddParsingInfo(flatParsingInfo);
          }

          flatCountFlag++;
        }
        flatRepository.UpdateRange(flats);
        flatRepository.SaveChanges();

        if (areParkingsParsing)
        {
          var parkings = (await parkingRepository.GetBuildingParkingsAsync(building.Id)).ToArray();
          if (parkings.Length == 0)
          {
            var parkingNumbers = Enumerable.Range(0, random.Next(15, 50));
            parkings = parkingNumbers.Select(i => Parking.Create(
              $"Паркинг {i}",
              null,
              building.Id,
              developerId,
              null,
              i.ToString(),
              null,
              (Status)random.Next(3))).ToArray();
            parkingRepository.AddRange(parkings);
            parkingRepository.SaveChanges();
          }

          var parkingCountFlag = 1;
          foreach (var parking in parkings)
          {
            if (parking.ParsingInfos.Count > 0) break;
            var number = flatCountFlag;
            var floor = random.Next(0, 3) * -1;
            var area = random.Next(14, 25) + random.NextDouble();
            var basePrice = random.Next(700000, 3000000);
            var soldParse = parking.CurrentStatus == Status.Sold ? parsings.ToArray()[random.Next(parsings.Count())] : null;
            foreach (var parse in parsings)
            {
              var status = soldParse is not null && parse.Id.Value == soldParse.Id.Value ? Status.Sold : random.Next(2) == 1 ? Status.Available : Status.Booked;
              var parkingParsingInfo = ParkingParsingInfo.Create(
                parse.Id,
                number.ToString(),
                floor.ToString(),
                area,
                building.Name,
                null,
                basePrice + (random.Next(2) == 1 ? 1 : -1) * random.Next(2000000),
                parse.Date,
                status
              );

              parking.AddParsingInfo(parkingParsingInfo);
            }

            parkingCountFlag++;
          }
          parkingRepository.UpdateRange(parkings);
          parkingRepository.SaveChanges();
        }

        if (areStoragesParsing)
        {
          var storages = (await storageRepository.GetBuildingStoragesAsync(building.Id)).ToArray();
          if (storages.Length == 0)
          {
            var storageNumbers = Enumerable.Range(0, random.Next(10, 25));
            storages = storageNumbers.Select(i => Storage.Create(
              $"Кладовая {i}",
              null,
              building.Id,
              developerId,
              null,
              i.ToString(),
              null,
              (Status)random.Next(3))).ToArray();
            storageRepository.AddRange(storages);
            storageRepository.SaveChanges();
          }

          var storageCountFlag = 1;
          foreach (var storage in storages)
          {
            if (storage.ParsingInfos.Count > 0) break;
            var number = storageCountFlag;
            var floor = random.Next(0, 2) * -1;
            var area = random.Next(4, 10) + random.NextDouble();
            var basePrice = random.Next(500000, 1500000);
            var soldParse = storage.CurrentStatus == Status.Sold ? parsings.ToArray()[random.Next(parsings.Count())] : null;
            foreach (var parse in parsings)
            {
              var status = soldParse is not null && parse.Id.Value == soldParse.Id.Value ? Status.Sold : random.Next(2) == 1 ? Status.Available : Status.Booked;
              var storageParsingInfo = StorageParsingInfo.Create(
                parse.Id,
                number.ToString(),
                floor.ToString(),
                area,
                building.Name,
                null,
                basePrice + (random.Next(2) == 1 ? 1 : -1) * random.Next(2000000),
                parse.Date,
                status
              );

              storage.AddParsingInfo(storageParsingInfo);
            }

            storageCountFlag++;
          }
          storageRepository.UpdateRange(storages);
          storageRepository.SaveChanges();
        }
      }
    }

    complexRepository.UpdateRange(newComplexes);
    await complexRepository.SaveChangesAsync();

    return true;
  }
}
