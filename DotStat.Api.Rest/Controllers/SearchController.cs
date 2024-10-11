using System.Net;
using DotStat.Api.Contracts.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

public class SearchController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public SearchController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Поиск ЖК и застройщиков
  /// </summary>
  /// <param name="search">Строка поиска</param>
  [ProducesResponseType(typeof(SearchResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet]
  public async Task<IActionResult> SearchComplexesAndDevelopers([FromQuery] string search)
  {
    throw new NotImplementedException();
  }
}