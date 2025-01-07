using Data.IServices;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Entities;

namespace Energy360_Info.Controllers
{
    [Route("api/consume")]
    [ApiController]
    public class RenewableEnergyConsumptionController : ControllerBase
    {

        private readonly IRenewableEnergyPlantService _renewableEnergyPlantService;

        public RenewableEnergyConsumptionController(IRenewableEnergyPlantService renewableEnergyPlantService)
        {
            _renewableEnergyPlantService = renewableEnergyPlantService;
        }

        [HttpGet("hours/{id}")]
        public async Task<ActionResult<List<RenewableEnergyConsumption>>> GetHourlyConsumption(int id, DateTime? date = null)
        {
            // Si no se proporciona una fecha, usa la fecha actual
            DateTime effectiveDate = date ?? DateTime.Today; // Usa DateTime.Today para evitar incluir la hora actual

            try
            {
                List<RenewableEnergyConsumption> consumptions;
                if (date.HasValue)
                {
                    // Si la fecha no incluye una hora específica (es decir, es exactamente medianoche)
                    if (date.Value.TimeOfDay == TimeSpan.Zero)
                    {
                        // Establece la hora actual a la fecha dada
                        effectiveDate = date.Value.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
                        // Devuelve todos los registros para el día especificado
                        DateTime startDate = effectiveDate.Date; // Medianoche del día especificado
                        DateTime endDate = startDate.AddDays(1); // Medianoche del siguiente día
                        consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, startDate, endDate);
                    }
                    else
                    {
                        // Establece la fecha efectiva con la hora exacta proporcionada
                        effectiveDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day,
                                                     date.Value.Hour, date.Value.Minute, date.Value.Second);

                        // Devuelve solo el registro para la hora especificada
                        consumptions = await _renewableEnergyPlantService.GetConsumptionByDateAndHour(id, effectiveDate);
                    }
                }
                else
                {
                    // Si no se proporciona una fecha, usa la fecha y hora actual
                    effectiveDate = DateTime.Now;
                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateAndHour(id, effectiveDate);
                }

                if (consumptions == null || consumptions.Count == 0)
                    return NotFound("No hourly consumption data found for the specified plant on the given date.");

                return Ok(consumptions);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }



    }
}

