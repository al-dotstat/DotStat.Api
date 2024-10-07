using System.Net;
using DotStat.Api.Contracts.Building;
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
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetBuilding(int id)
  {
    throw new NotImplementedException();
  }
}