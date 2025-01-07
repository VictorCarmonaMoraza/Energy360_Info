using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Entities
{
    public class RenewableEnergyConsumption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Plant")]
        public int PlantId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyConsumption { get; set; } // Consumo horario en kWh

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DailyConsumption { get; set; } // Consumo diario en kWh (opcional)

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MonthlyConsumption { get; set; } // Consumo mensual en kWh (opcional)

        [Column(TypeName = "decimal(18,2)")]
        public decimal? YearlyConsumption { get; set; } // Consumo anual en kWh (opcional)
    }
}
