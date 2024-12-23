using System.Net;
using DotStat.Api.Application.Developing.Queries.SearchQueries;
using DotStat.Api.Contracts.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

[Authorize]
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
  [ProducesResponseType(typeof(SearchResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpGet]
  public async Task<IActionResult> SearchComplexesAndDevelopers([FromQuery] string search)
  {
    var query = new SearchQuery(search);
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<SearchResponse>(res)),
      Problem
    );
  }
}