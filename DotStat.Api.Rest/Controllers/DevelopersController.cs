using System.Net;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.Developer;
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
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetDeveloper(int id)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить всех застройщиков
  /// </summary>
  /// <param name="id">Id застройщика</param>
  [ProducesResponseType(typeof(DeveloperResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet]
  public async Task<IActionResult> GetAllDevelopers()
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить все ЖК застройщика
  /// </summary>
  /// <param name="id">Id застройщика</param>
  [ProducesResponseType(typeof(ComplexResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetDeveloperComplexes(int id)
  {
    throw new NotImplementedException();
  }
}