using System.Net;
using DotStat.Api.Contracts.Building;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.Developer;
using DotStat.Api.Contracts.Parse;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

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
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetComplex(int id)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить все ЖК
  /// </summary>
  [ProducesResponseType(typeof(ComplexResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet]
  public async Task<IActionResult> GetAllComplexes()
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить всех здания в ЖК
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(BuildingResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}/buildings")]
  public async Task<IActionResult> GetComplexBuildings(int id)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить всех застройщиков ЖК
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(DeveloperResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}/developers")]
  public async Task<IActionResult> GetComplexDevelopers(int id)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить информацию о датах парсинга и типах объектов в них
  /// </summary>
  /// <param name="id">Id ЖК</param>
  [ProducesResponseType(typeof(ParseResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}/parsed")]
  public async Task<IActionResult> GetComplexParsedInfo(int id)
  {
    throw new NotImplementedException();
  }
}