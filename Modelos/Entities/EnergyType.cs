using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Entities;

public class EnergyType
{
    [Key]
    public int EnergyTypeId { get; set; }
    public string Name { get; set; }
    [Column(TypeName = "varchar(500)")]
    public string Description { get; set; }

}
