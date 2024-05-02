using System.ComponentModel.DataAnnotations.Schema;

namespace testeLogicoBTI.Models;

public class BaseEntity
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}