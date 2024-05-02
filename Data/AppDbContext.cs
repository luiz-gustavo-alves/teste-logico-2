using Microsoft.EntityFrameworkCore;
using testeLogicoBTI.Models;

namespace testeLogicoBTI.Data;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
  public DbSet<Condutor> Condutor { get; set; } = null!;
  public DbSet<Passagem> Passagem { get; set; } = null!;
  public DbSet<Pedagio> Pedagio { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Condutor>().HasKey(b => b.Id);
    builder.Entity<Pedagio>().HasKey(b => b.Id);
    builder.Entity<Passagem>().HasKey(b => b.Id);

    builder.Entity<Condutor>().Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    builder.Entity<Condutor>().Property(b => b.CreatedAt).HasDefaultValueSql("now()");
    builder.Entity<Pedagio>().Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    builder.Entity<Pedagio>().Property(b => b.CreatedAt).HasDefaultValueSql("now()");
    builder.Entity<Passagem>().Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    builder.Entity<Passagem>().Property(b => b.CreatedAt).HasDefaultValueSql("now()");
  }
}