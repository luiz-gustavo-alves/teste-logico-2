using testeLogicoBTI.Models;
using testeLogicoBTI.Repositories;

namespace testeLogicoBTI.Services;

public class CondutorService(CondutorRepository condutorRepository)
{
  private readonly CondutorRepository _condutorRepository = condutorRepository;

  public async Task<Condutor> CreateCondutor()
  {
    Condutor condutor = new();
    return await _condutorRepository.CreateAsync(condutor);
  }
}