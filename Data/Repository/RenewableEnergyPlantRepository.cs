using ClosedXML.Excel;
using Data.DbContext_Conection;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using Modelos.Entities;
using System.Globalization;

namespace Data.Repository;

public class RenewableEnergyPlantRepository : IRenewableEnergyPlantRepository
{
    private readonly ApplicationDbContext _context;
    public RenewableEnergyPlantRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    //Guarda planta en BD
    public async Task SavePlant(RenewableEnergyPlant plant)
    {
        _context.RenewableEnergyPlants.Add(plant);
        await _context.SaveChangesAsync();
    }

    //Obtiene todos las plantas
    public async Task<List<RenewableEnergyPlant>> GetAllPlants()
    {
        //Obtener todos los id de las plantas
        var idsPlant = await _context.RenewableEnergyPlants.Select(x => x.Id).ToListAsync();
        var listPlant = new List<RenewableEnergyPlant>();
        //Por cada id de planta obtener el historial de la planta
        foreach (var id in idsPlant)
        {
            // Obtener la planta
            var plant = await _context.RenewableEnergyPlants
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plant != null)
            {
                // Obtener el historial de la planta
                // Obtener los 10 registros más recientes o registros de los últimos 10 meses
                var history = await _context.RenewableEnergyDataHistorys
                    .Where(x => x.PlantId == id && x.RecordDate >= DateTime.Now.AddMonths(-10)) // Últimos 10 meses
                    .OrderByDescending(x => x.RecordDate) // Ordenar por fecha descendente
                    .Take(10) // Tomar los 10 registros más recientes
                    .ToListAsync();

                // Asignar el historial a la propiedad de la planta
                plant.RenewableEnergyDataHistories = history.Any() ? history : null;

                // Añadir la planta a la lista
                listPlant.Add(plant);
            }
        }
        return listPlant;

        ////Devolverlo todo

        //return await _context.RenewableEnergyPlants
        // .Include(plant => plant.RenewableEnergyDataHistories) // Incluye el historial
        // .Where(plant => plant.RenewableEnergyDataHistories.Any() || !plant.RenewableEnergyDataHistories.Any())
        // .ToListAsync();

    }

    public async Task<List<RenewableEnergyDataHistory>> GetHistoryPlant(int id)
    {
        return await _context.RenewableEnergyDataHistorys.Where(x => x.PlantId == id).ToListAsync();
    }


    public async Task<bool> ImportPlantFromExcel(Stream excelFile)
    {
        var newPlants = new List<RenewableEnergyDataHistory>();
        var cultureInfo = new CultureInfo("es-ES");

        using (var workbook = new XLWorkbook(excelFile))
        {
            var worksheet = workbook.Worksheet(1); // Lee la primera hoja del archivo
            var rows = worksheet.RangeUsed().RowsUsed(); // Obtiene las filas con datos

            foreach (var row in rows.Skip(1)) // Omite la primera fila si es un encabezado
            {
                try
                {
                    var plant = new RenewableEnergyDataHistory
                    {
                        PlantId = int.Parse(row.Cell(1).GetValue<string>()),
                        RecordDate = DateTime.Parse(row.Cell(2).GetValue<string>()),
                        EstimatedAnnualProduction = double.Parse(row.Cell(3).GetValue<string>(), cultureInfo),
                        EmissionsAvoided = double.Parse(row.Cell(4).GetValue<string>(), cultureInfo),
                        ConstructionCostAmpliacion = decimal.Parse(row.Cell(5).GetValue<string>(), cultureInfo),
                        NumberOfUnits = int.Parse(row.Cell(6).GetValue<string>()),
                        CapacityFactor = double.Parse(row.Cell(7).GetValue<string>(), cultureInfo),
                        TechnologyProvider = row.Cell(8).GetValue<string>(),
                        Rating = int.Parse(row.Cell(9).GetValue<string>()),
                    };

                    newPlants.Add(plant);
                }
                catch (FormatException ex)
                {
                    // Manejo del error de formato
                    throw new Exception($"Error al procesar la fila {row.RowNumber()}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Manejo general de errores
                    throw new Exception($"Error inesperado al procesar la fila {row.RowNumber()}: {ex.Message}");
                }
            }
        }
        await _context.RenewableEnergyDataHistorys.AddRangeAsync(newPlants);
        await _context.SaveChangesAsync();
        return true;
    }

    //Comrpobar que el nombre de la planta no exista en BBDD
    public async Task<bool> ValidatePlantExists(RenewableEnergyPlant renewableEnergyPlant)
    {
        bool exists = await _context.RenewableEnergyPlants.AnyAsync(x =>
        x.Name == renewableEnergyPlant.Name &&
        (x.EnergyTypeId != renewableEnergyPlant.EnergyTypeId || x.Country != renewableEnergyPlant.Country || x.CityOrRegion != renewableEnergyPlant.CityOrRegion)
        );
        return exists;
    }
}