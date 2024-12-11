using Data.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Energy360_Info.Controllers
{
    [Route("api/energy")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        private readonly IEnergyService _energyService;
        public EnergyController(IEnergyService energyService)
        {
            _energyService = energyService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var energy = await _energyService.GetAllEnergyTypes();
                return Ok(energy);
            }
            catch (Exception)
            {
                return BadRequest("ha surgido un problema");
            }
        }
    }
}
