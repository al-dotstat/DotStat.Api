using DotStat.Api.Application.Fake;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

[Authorize]
public class FakeController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public FakeController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost]
  public async Task<IActionResult> GenerateFakeData()
  {
    var query = new FakeCommand();
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(),
      Problem
    );
  }
}