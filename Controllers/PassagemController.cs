using Microsoft.AspNetCore.Mvc;
using testeLogicoBTI.DTOs;
using testeLogicoBTI.Models;
using testeLogicoBTI.Services;

namespace testeLogicoBTI.Controllers;

[ApiController]
[Route("/passagem")]
public class PassagemController(PassagemService passagemService) : ControllerBase
{
  private readonly PassagemService _passagemService = passagemService;

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    Passagem passagem = await _passagemService.GetPassagemById(id);
    return Ok(passagem);
  }

  [HttpPut]
  public async Task<IActionResult> Update(AtualizarPassagemDTO dto)
  {
    OutputAtualizarPassagemDTO outputDTO = await _passagemService.UpdatePassagem(dto);
    return Ok(outputDTO);
  }
}