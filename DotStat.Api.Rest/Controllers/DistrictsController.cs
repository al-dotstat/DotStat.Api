using System.Net;
using DotStat.Api.Application.Developing.Queries.ComplexQueries;
using DotStat.Api.Application.Developing.Queries.DistrictQueries;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.District;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

public class DistrictsController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public DistrictsController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить район по Id
  /// </summary>
  /// <param name="id">Id района</param>
  [ProducesResponseType(typeof(DistrictResponse), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetDistrict(int id)
  {
    var query = new DistrictQuery(DistrictId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<DistrictResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить все районы
  /// </summary>
  [ProducesResponseType(typeof(DistrictResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet]
  public async Task<IActionResult> GetAllDistricts()
  {
    var query = new DistrictsQuery();
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<DistrictResponse[]>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить все ЖК в районе
  /// </summary>
  /// <param name="id">Id района</param>
  [ProducesResponseType(typeof(ComplexResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}/complexes")]
  public async Task<IActionResult> GetDistrictComplexes(int id)
  {
    var query = new DistrictComplexesQuery(DistrictId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<ComplexResponse[]>(res)),
      Problem
    );
  }
}