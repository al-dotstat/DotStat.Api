using System.Net;
using DotStat.Api.Application.Developing.Queries.ComplexQueries;
using DotStat.Api.Application.Infrastructure.Queries.DistrictQueries;
using DotStat.Api.Contracts.Common;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.District;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

[Authorize]
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
  [Produces("application/json")]
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
  [ProducesResponseType(typeof(CollectionResponse<DistrictResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet]
  public async Task<IActionResult> GetAllDistricts()
  {
    var query = new DistrictsQuery();
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<DistrictResponse>>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить все ЖК в районе
  /// </summary>
  /// <param name="id">Id района</param>
  [ProducesResponseType(typeof(CollectionResponse<ComplexResponse>), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/complexes")]
  public async Task<IActionResult> GetDistrictComplexes(int id)
  {
    var query = new DistrictComplexesQuery(DistrictId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<CollectionResponse<ComplexResponse>>(res)),
      Problem
    );
  }
}