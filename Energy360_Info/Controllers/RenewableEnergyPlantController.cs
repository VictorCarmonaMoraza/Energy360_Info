﻿using Data.IServices;
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


        /// <summary>
        /// Creacion de una planta
        /// </summary>
        /// <param name="renewableEnergyPlant"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> SavePlant([FromBody] RenewableEnergyPlant renewableEnergyPlant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                // Verificar si la planta ya existe
                bool exists = await _renewableEnergyPlantService.ValidatePlantExists(renewableEnergyPlant);
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

        /// <summary>
        /// Obtenemos todas las plantas que tenemos en el sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("allPlants")]
        public async Task<IActionResult> GetAllPlants()
        {
            try
            {
                var plants = await _renewableEnergyPlantService.GetAllPlants();

                return Ok(plants);
            }
            catch (Exception ex)
            {
                return BadRequest("ha surgido un problema"+ ex.Message);
            }
        }

        /// <summary>
        /// Obtenerr histortico de una plantab por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //Obtenr informacion de una planta por su id
        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetPlantById(int id)
        {
            try
            {
                var plant = await _renewableEnergyPlantService.GetPlantById(id);
                return Ok(plant);
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

        /// <summary>
        /// Importar historica de plantas mediante excel
        /// </summary>
        /// <param name="file">nombre del fichero</param>
        /// <returns></returns>
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

        [HttpGet("average")]
        public async Task<IActionResult> GetAverageProduction()
        {
            try
            {
                //Obtenemos todas las plantas
                var plants = await _renewableEnergyPlantService.GetAllPlants();
                //var average = await _renewableEnergyPlantService.GetAverageProduction();
                return Ok(plants);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }
}
