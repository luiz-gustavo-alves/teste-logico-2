using Microsoft.AspNetCore.Mvc;
using testeLogicoBTI.DTOs;
using testeLogicoBTI.Models;
using testeLogicoBTI.Services;

namespace testeLogicoBTI.Controllers;

[ApiController]
[Route("/pedagio")]
public class PedagioController(PedagioService pedagioService) : ControllerBase
{
  private readonly PedagioService _pedagioService = pedagioService;

  [HttpPost]
  public async Task<IActionResult> Create(CriarPedagioDTO dto)
  {
    Pedagio pedagio = await _pedagioService.CreatePedagio(dto);
    return Ok(pedagio);
  }
}