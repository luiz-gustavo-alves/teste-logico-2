using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testeLogicoBTI.Models;

public class Passagem : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Condutor))]
    public Guid CondutorId { get; set; }

    [ForeignKey(nameof(Pedagio))]
    public Guid PedagioId { get; set; }

    public int Contador { get; set; } = 1;

    public int MesAtual { get; set; } = DateTime.Now.Month;

    public int AnoAtual { get; set; } = DateTime.Now.Year;

    public Condutor Condutor { get; set; } = null!;

    public Pedagio Pedagio { get; set; } = null!;
}