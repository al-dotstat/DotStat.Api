using System.Net;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.District;
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
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить все районы
  /// </summary>
  [ProducesResponseType(typeof(DistrictResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet]
  public async Task<IActionResult> GetAllDistricts()
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить все ЖК в районе
  /// </summary>
  /// <param name="id">Id района</param>
  [ProducesResponseType(typeof(ComplexResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}/complexes")]
  public async Task<IActionResult> GetDistrictComplexes(int id)
  {
    throw new NotImplementedException();
  }
}