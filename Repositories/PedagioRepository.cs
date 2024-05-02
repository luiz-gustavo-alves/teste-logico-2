using Microsoft.EntityFrameworkCore;
using testeLogicoBTI.Data;
using testeLogicoBTI.Models;

namespace testeLogicoBTI.Repositories;

public class PedagioRepository(AppDBContext context)
{
  private readonly AppDBContext _context = context;

  public async Task<Pedagio> CreateAsync(Pedagio pedagio)
  {
    _context.Pedagio.Add(pedagio);
    await _context.SaveChangesAsync();
    return pedagio;
  }

  public async Task<Pedagio?> GetById(Guid id)
  {
    return await _context.Pedagio.FirstOrDefaultAsync(c => c.Id.Equals(id));
  }
}