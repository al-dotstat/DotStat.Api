using System.Net;
using DotStat.Api.Application.Developing.Queries.BuildingQueries;
using DotStat.Api.Application.Developing.Queries.ComplexQueries;
using DotStat.Api.Application.Developing.Queries.DeveloperQueries;
using DotStat.Api.Application.Developing.Queries.SearchQueries;
using DotStat.Api.Application.Parsing.Queries.ParsedQueries;
using DotStat.Api.Contracts.Building;
using DotStat.Api.Contracts.Common;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.Developer;
using DotStat.Api.Contracts.Parse;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DotStat.Api.Rest.Controllers;

[Authorize]
public class ComplexesController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public ComplexesController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить ЖК по Id
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(ComplexResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetComplex(int id)
  {
    var query = new ComplexQuery(ComplexId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<ComplexResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Скачать парсинг ЖК
  /// </summary>
  /// <param name="id">Id ЖК</param>
  /// <param name="includeFlats">Включить квартиры в файл</param>
  /// <param name="includeParkings">Включить паркинг в файл</param>
  /// <param name="includeStorages">Включить кладовые в файл</param>
  /// <param name="includeCommercials">Включить коммерцию в файл</param>
  [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/parse")]
  public async Task<IActionResult> GetComplexParse(
    int id,
    [FromQuery] bool includeFlats,
    [FromQuery] bool includeParkings,
    [FromQuery] bool includeStorages,
    [FromQuery] bool includeCommercials)
  {
    var query = new ComplexExportQuery(
      ComplexId.Create(id),
      includeFlats,
      includeParkings,
      includeStorages,
      includeCommercials);
    var result = await _mediator.Send(query);

    return result.Match(
      res =>
      {
        new FileExtensionContentTypeProvider().TryGetContentType(res.FileName, out string? contentType);
        return File(res.Body, contentType ?? "", res.FileName);
      },
      Problem
    );
  }

  /// <summary>
  /// Получить таблицу парсинга ЖК
  /// </summary>
  /// <param name="id">Id ЖК</param>
  /// <param name="includeFlats">Включить квартиры</param>
  /// <param name="includeParkings">Включить паркинг</param>
  /// <param name="includeStorages">Включить кладовые</param>
  /// <param name="includeCommercials">Включить коммерцию</param>
  [ProducesResponseType(typeof(ComplexTableResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/parse/table")]
  public async Task<IActionResult> GetComplexParseTable(
    int id,
    [FromQuery] bool includeFlats,
    [FromQuery] bool includeParkings,
    [FromQuery] bool includeStorages,
    [FromQuery] bool includeCommercials)
  {
    var query = new ComplexTableQuery(
      ComplexId.Create(id),
      includeFlats,
      includeParkings,
      includeStorages,
      includeCommercials);
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<ComplexTableResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить все ЖК
  /// </summary>
  [ProducesResponseType(typeof(CollectionResponse<ComplexResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet]
  public async Task<IActionResult> GetAllComplexes()
  {
    var query = new AllComplexesQuery();
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<ComplexResponse>>(res)),
      Problem
    );
  }

  /// <summary>
  /// Поиск ЖК по фильтрам
  /// </summary>
  /// <param name="developersIds">Id застройщиков</param>
  /// <param name="districtsIds">Id районов</param>
  /// <param name="search">Строка поиска по названию</param>
  [ProducesResponseType(typeof(CollectionResponse<ComplexResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("search")]
  public async Task<IActionResult> SearchComplexes(
    [FromQuery(Name = "developersIds[]")] int[]? developersIds,
    [FromQuery(Name = "districtsIds[]")] int[]? districtsIds,
    [FromQuery] string? search)
  {
    var developersIdsCasted = (developersIds ?? []).Select(x => DeveloperId.Create(x));
    var districtsIdsCasted = (districtsIds ?? []).Select(x => DistrictId.Create(x));

    var query = new ComplexesByFiltersQuery(
      developersIdsCasted,
      districtsIdsCasted,
      search ?? ""
    );
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<ComplexResponse>>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить все здания в ЖК
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(CollectionResponse<BuildingResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/buildings")]
  public async Task<IActionResult> GetComplexBuildings(int id)
  {
    var query = new ComplexBuildingsQuery(ComplexId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<BuildingResponse>>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить всех застройщиков ЖК
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(CollectionResponse<DeveloperResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/developers")]
  public async Task<IActionResult> GetComplexDevelopers(int id)
  {
    var query = new ComplexDevelopersQuery(ComplexId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<DeveloperResponse>>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить информацию о датах парсинга и типах объектов в них
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(CollectionResponse<ParseResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/parsed")]
  public async Task<IActionResult> GetComplexParsedInfo(int id)
  {
    var query = new ComplexParsedQuery(ComplexId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<ParseResponse>>(res)),
      Problem
    );
  }
}