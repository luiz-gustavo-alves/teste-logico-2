using Microsoft.AspNetCore.Mvc;
using testeLogicoBTI.Models;
using testeLogicoBTI.Services;

namespace testeLogicoBTI.Controllers;

[ApiController]
[Route("/condutor")]
public class CondutorController(CondutorService condutorService) : ControllerBase
{
  private readonly CondutorService _condutorService = condutorService;

  [HttpPost]
  public async Task<IActionResult> Create()
  {
    Condutor condutor = await _condutorService.CreateCondutor();
    return Ok(condutor);
  }
}