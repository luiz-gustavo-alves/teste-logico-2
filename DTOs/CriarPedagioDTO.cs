using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace testeLogicoBTI.DTOs;

public class CriarPedagioDTO
{
  [Required(ErrorMessage = "{0} é obrigatório.")]
  [DataMember(Name = "preco")]
  public required int Preco { get; set; }
}