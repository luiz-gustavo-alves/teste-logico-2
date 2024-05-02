using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace testeLogicoBTI.DTOs;

public class CriarPedagioDTO
{
  [Required(ErrorMessage = "{0} é obrigatório.")]
  [Range(100, int.MaxValue, ErrorMessage = "O valor do preço tem que ser maior que 100")]
  [DataMember(Name = "preco")]
  public required int Preco { get; set; }
}