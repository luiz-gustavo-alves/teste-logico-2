using Microsoft.EntityFrameworkCore;
using testeLogicoBTI.Data;
using testeLogicoBTI.Models;

namespace testeLogicoBTI.Repositories;

public class CondutorRepository(AppDBContext context)
{
  private readonly AppDBContext _context = context;

  public async Task<Condutor> CreateAsync(Condutor condutor)
  {
    _context.Condutor.Add(condutor);
    await _context.SaveChangesAsync();
    return condutor;
  }

  public async Task<Condutor?> GetById(Guid id)
  {
    return await _context.Condutor.FirstOrDefaultAsync(c => c.Id.Equals(id));
  }
}