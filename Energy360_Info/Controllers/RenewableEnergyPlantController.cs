using Data.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Entities;

namespace Energy360_Info.Controllers
{
    [Route("api/plant")]
    [ApiController]
    public class RenewableEnergyPlantController : ControllerBase
    {
        private readonly IRenewableEnergyPlantService _renewableEnergyPlantService;
        
        public RenewableEnergyPlantController(IRenewableEnergyPlantService renewableEnergyPlantService)
        {
            _renewableEnergyPlantService = renewableEnergyPlantService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> SavePlant([FromBody] RenewableEnergyPlant renewableEnergyPlant)
        {
            try
            {
                // Verificar si la planta ya existe
                bool exists = await _renewableEnergyPlantService.ValidateNamePlantExists(renewableEnergyPlant);
                if (exists)
                {
                    return BadRequest(new { message = "La planta " + renewableEnergyPlant.Name + " ya existe en la base de datos." });
                }

                // Guardar la nueva planta en la base de datos
                await _renewableEnergyPlantService.SavePlant(renewableEnergyPlant);
                return Ok(new { message = "Planta de energía creada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear la planta de energía.", details = ex.Message });
            }
        }

        //Obtener todos los usuarios
        [HttpGet("allPlants")]
        public async Task<IActionResult> GetAllPlants()
        {
            try
            {
                var plants = await _renewableEnergyPlantService.GetAllPlants();
                return Ok(plants);
            }
            catch (Exception)
            {
                return BadRequest("ha surgido un problema");
            }
        }

        [HttpGet("historyPlant/{id}")]
        public async Task<IActionResult> GetHistoryPlant(int id)
        {
            try
            {
                var history = await _renewableEnergyPlantService.GetHistoryPlant(id);
                return Ok(history);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("importar")]
        public async Task<IActionResult> ImportarDesdeExcel([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Por favor, suba un archivo Excel válido.");
            }

            using (var stream = file.OpenReadStream())
            {
                bool insercionExitosa = await _renewableEnergyPlantService.ImportPlantFromExcel(stream);

                if (insercionExitosa)
                {
                    return Ok("Los datos se insertaron correctamente.");
                }
                else
                {
                    return StatusCode(500, "Hubo un problema al insertar los datos.");
                }
            }
        }

        [HttpPost("importar2")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Procesamiento del archivo

            return Ok("File processed successfully.");
        }



    }
}
