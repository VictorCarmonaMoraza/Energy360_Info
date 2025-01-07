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

        //Obtencion del diario
        //Obtención del consumo diario
        [HttpGet("daily/{id}")]
        public async Task<ActionResult<List<RenewableEnergyConsumption>>> GetDailyConsumption(int id, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            try
            {
                List<RenewableEnergyConsumption> consumptions;

                if (dateStart.HasValue && dateEnd.HasValue)
                {
                    // Si se proporcionan ambas fechas, obtiene los consumos en el rango de fechas
                    DateTime startDate = dateStart.Value.Date; // Asegura que la fecha de inicio sea a medianoche
                    DateTime endDate = dateEnd.Value.Date.AddDays(1); // Incluye todo el último día
                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, startDate, endDate);
                }
                else
                {
                    // Si no se proporcionan fechas, usa la fecha actual
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);
                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, today, tomorrow);
                }

                if (consumptions == null || consumptions.Count == 0)
                    return NotFound("No daily consumption data found for the specified plant within the provided date range.");

                return Ok(consumptions);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // Obtención del consumo mensual
        [HttpGet("monthly/{id}")]
        public async Task<ActionResult<List<RenewableEnergyConsumption>>> GetMonthlyConsumption(int id, DateTime? date = null)
        {
            try
            {
                List<RenewableEnergyConsumption> consumptions;

                if (date.HasValue)
                {
                    // Si se proporciona una fecha, obtiene los consumos del mes especificado
                    DateTime startDate = new DateTime(date.Value.Year, date.Value.Month, 1); // Primer día del mes
                    DateTime endDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day); // La fecha exacta proporcionada
                    endDate = endDate.AddDays(1); // Ajuste para incluir el último día hasta la medianoche
                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, startDate, endDate);
                }
                else
                {
                    // Si no se proporciona una fecha, obtiene los consumos desde el primer día del mes actual hasta la fecha actual
                    DateTime today = DateTime.Today;
                    DateTime startDate = new DateTime(today.Year, today.Month, 1); // Primer día del mes
                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, startDate, today.AddDays(1)); // Hasta la medianoche de hoy para incluir todo el día actual
                }

                if (consumptions == null || consumptions.Count == 0)
                    return NotFound("No monthly consumption data found for the specified plant on the given date.");

                return Ok(consumptions);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        //Obtencion del consumo anual
        [HttpGet("yearly/{id}")]
        public async Task<ActionResult<List<RenewableEnergyConsumption>>> GetYearlyConsumption(int id, DateTime? date = null)
        {
            try
            {
                List<RenewableEnergyConsumption> consumptions;

                if (date.HasValue)
                {
                    // Si se proporciona una fecha, obtiene los consumos del año especificado
                    DateTime startDate = new DateTime(date.Value.Year, 1, 1); // Primer día del año
                    DateTime endDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day); // La fecha exacta proporcionada
                    endDate = endDate.AddDays(1); // Ajuste para incluir el último día hasta la medianoche
                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, startDate, endDate);
                }
                else
                {
                    // Si no se proporciona una fecha, obtiene los consumos desde la misma fecha del año anterior hasta la fecha actual
                    DateTime today = DateTime.Today;
                    DateTime startDate = today.AddYears(-1); // Mismo día del año anterior
                    DateTime endDate = today.AddDays(1); // Incluye todo el día actual hasta la medianoche

                    consumptions = await _renewableEnergyPlantService.GetConsumptionByDateRange(id, startDate, endDate);
                }

                if (consumptions == null || consumptions.Count == 0)
                    return NotFound("No yearly consumption data found for the specified plant on the given date.");

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

