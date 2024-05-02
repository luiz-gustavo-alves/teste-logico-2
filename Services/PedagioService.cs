using testeLogicoBTI.DTOs;
using testeLogicoBTI.Models;
using testeLogicoBTI.Repositories;

namespace testeLogicoBTI.Services;

public class PedagioService(PedagioRepository pedagioRepository)
{
  private readonly PedagioRepository _pedagioRepository = pedagioRepository;

  public async Task<Pedagio> CreatePedagio(CriarPedagioDTO dto)
  {
    Pedagio pedagio = new() { Preco = dto.Preco };
    return await _pedagioRepository.CreateAsync(pedagio);
  }
}