﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Entities;

public class RenewableEnergyPlant
{
    // Identificador único de la planta
    public int Id { get; set; }

    // Nombre de la planta
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    // Tipo de energía (eólica, solar, hidroeléctrica, biomasa, geotérmica, etc.)
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string EnergyType { get; set; }

    // País donde se encuentra la planta
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Country { get; set; }

    // Ciudad o Región donde se encuentra la planta
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string CityOrRegion { get; set; }

    // Coordenadas GPS (Latitud)
    [Required]
    public double Latitude { get; set; }

    // Coordenadas GPS (Longitud)
    [Required]
    public double Longitude { get; set; }

    // Capacidad instalada en MW
    [Required]
    public double InstalledCapacity { get; set; }

    // Fecha de inicio de operaciones
    public DateTime StartDate { get; set; }

    // Empresa operadora o propietaria
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Owner { get; set; }

    // Estado actual de la planta (operativa, en construcción, fuera de servicio)
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Status { get; set; }

    // Producción anual estimada en MWh
    [Required]
    public double EstimatedAnnualProduction { get; set; }

    // Emisiones evitadas en toneladas de CO2 o equivalente
    [Required]
    public double EmissionsAvoided { get; set; }

    // Costo de construcción de la planta
    public decimal ConstructionCost { get; set; }

    // Número de turbinas o paneles (si aplica)
    [Required]
    public int NumberOfUnits { get; set; }

    // Factor de capacidad (relación entre producción real y capacidad teórica)
    [Required]
    public double CapacityFactor { get; set; }

    // Proveedor de la tecnología utilizada
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string TechnologyProvider { get; set; }
}
