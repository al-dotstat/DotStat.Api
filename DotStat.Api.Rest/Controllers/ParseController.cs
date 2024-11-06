using System.Net;
using DotStat.Api.Contracts.Parse;
using DotStat.Api.Rest.Controllers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ParseController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public ParseController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить текущую очередь на парсинг
  /// </summary>
  [ProducesResponseType(typeof(ParseQueueResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet("queue")]
  public async Task<IActionResult> GetParseQueue()
  {
    throw new NotImplementedException();
  }


  /// <summary>
  /// Добавить в очередь
  /// </summary>
  [ProducesResponseType(typeof(ParseQueueResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpPost("queue")]
  public async Task<IActionResult> AddToQueue([FromBody] int ComplexId)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Удалить из очереди
  /// </summary>
  [ProducesResponseType(typeof(ParseQueueResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpDelete("queue")]
  public async Task<IActionResult> DeleteFromQueue([FromBody] int ComplexId)
  {
    throw new NotImplementedException();
  }
}