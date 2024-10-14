using System.Net;
using DotStat.Api.Application.Developing.Queries.ComplexQueries;
using DotStat.Api.Application.Developing.Queries.DeveloperQueries;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.Developer;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

public class DevelopersController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public DevelopersController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить застройщика по Id
  /// </summary>
  /// <param name="id">Id застройщика</param>
  [ProducesResponseType(typeof(DeveloperResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetDeveloper(int id)
  {
    var query = new DeveloperQuery(DeveloperId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<DeveloperResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить всех застройщиков
  /// </summary>
  [ProducesResponseType(typeof(DeveloperResponse[]), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet]
  public async Task<IActionResult> GetAllDevelopers()
  {
    var query = new AllDevelopersQuery();
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<DeveloperResponse[]>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить все ЖК застройщика
  /// </summary>
  /// <param name="id">Id застройщика</param>
  [ProducesResponseType(typeof(ComplexResponse[]), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("{id:int}/complexes")]
  public async Task<IActionResult> GetDeveloperComplexes(int id)
  {
    var query = new DeveloperComplexesQuery(DeveloperId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<ComplexResponse[]>(res)),
      Problem
    );
  }
}