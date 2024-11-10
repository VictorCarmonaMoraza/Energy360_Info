using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entities
{
    public class RenewableEnergyDataHistory
    {
        [Key]
        public int HistoryId { get; set; }

        [ForeignKey("RenewableEnergyPlant")]
        public int PlantId { get; set; } // Clave foránea de RenewableEnergyPlant

        // Fecha de la captura del dato
        public DateTime RecordDate { get; set; }

        // Producción anual estimada en ese momento
        public double EstimatedAnnualProduction { get; set; }

        // Emisiones evitadas registradas en ese momento
        public double EmissionsAvoided { get; set; }

        // Costo de construcción registrado
        public decimal ConstructionCostAmpliacion { get; set; }

        // Número de unidades en ese momento
        public int NumberOfUnits { get; set; }

        // Factor de capacidad registrado
        public double CapacityFactor { get; set; }

        // Proveedor de la tecnología en ese momento
        public string TechnologyProvider { get; set; }

        // Calificación de la planta en ese momento
        public int Rating { get; set; }
    }
}
