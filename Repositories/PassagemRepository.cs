using Microsoft.EntityFrameworkCore;
using testeLogicoBTI.Data;
using testeLogicoBTI.Models;

namespace testeLogicoBTI.Repositories;

public class PassagemRepository(AppDBContext context)
{
  private readonly AppDBContext _context = context;

  public async Task<Passagem> CreateAsync(Passagem passagem)
  {
    _context.Passagem.Add(passagem);
    await _context.SaveChangesAsync();
    return passagem;
  }

  public async Task<Passagem?> GetById(Guid id) 
  {
    return await _context.Passagem.FirstOrDefaultAsync(c => c.Id.Equals(id));
  }

  public async Task<Passagem?> GetByCondutorAndPedagioIds(Guid condutorId, Guid pedagioId)
  {
    return await _context.Passagem.FirstOrDefaultAsync(
      c => c.CondutorId.Equals(condutorId) &&
      c.PedagioId.Equals(pedagioId)
    );
  }

  public async Task<Passagem> Update(Passagem passagem) 
  { 
    passagem.UpdatedAt = DateTime.UtcNow;
    await _context.SaveChangesAsync();
    return passagem;
  }
}