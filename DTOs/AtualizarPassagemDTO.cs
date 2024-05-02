using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace testeLogicoBTI.DTOs;

public class AtualizarPassagemDTO
{

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DataMember(Name = "condutorId")]
  public required Guid CondutorId { get; set; }

  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DataMember(Name = "pedagioId")]
  public required Guid PedagioId { get; set; }
}

public class OutputAtualizarPassagemDTO
{
  [DataMember(Name = "condutorId")]
  public required Guid CondutorId { get; set; }

  [DataMember(Name = "pedagioId")]
  public required Guid PedagioId { get; set; }

  [DataMember(Name = "discount")]
  public double Preco { get; set; }

  [DataMember(Name = "updatedAt")]
  public DateTime UpdatedAt { get; set; }
}