using System.Net;
using DotStat.Api.Application.Developing.Queries.BuildingQueries;
using DotStat.Api.Contracts.Building;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

public class BuildingsController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public BuildingsController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить строение по Id
  /// </summary>
  /// <param name="id">Id строения</param>
  [ProducesResponseType(typeof(BuildingResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetBuilding(int id)
  {
    var query = new BuildingQuery(BuildingId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<BuildingResponse>(res)),
      Problem
    );
  }
}