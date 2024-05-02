using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testeLogicoBTI.Models;

public class Pedagio : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public int Preco { get; set; }

    public ICollection<Passagem> Passagem { get; set; } = null!;
}