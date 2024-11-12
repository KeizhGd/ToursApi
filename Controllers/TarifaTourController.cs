using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.TarifaTourService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TarifaTourController : ControllerBase
    {
        private readonly ITarifaTourServices _tarifaService;

        public TarifaTourController(ITarifaTourServices tarifaService)
        {
            _tarifaService = tarifaService;
        }

        [HttpGet]
        [Route("GetAllTarifas")]
        public async Task<IActionResult> GetAllTarifas()
        {
            try
            {
                var result = await _tarifaService.GetAllTarifas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetTarifaById/{id}")]
        public async Task<IActionResult> GetTarifaById(int id)
        {
            try
            {
                var result = await _tarifaService.GetTarifaById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        [HttpPost]
        [Route("CreateTarifa")]
        public async Task<IActionResult> CreateTarifa([FromBody] TarifaTourModel newTarifa)
        {
            try
            {
                var result = await _tarifaService.CreateTarifa(newTarifa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTarifa/{id}")]
        public async Task<IActionResult> UpdateTarifa(int id, [FromBody] TarifaTourModel updatedTarifa)
        {
            try
            {
                var result = await _tarifaService.UpdateTarifa(id, updatedTarifa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTarifa/{id}")]
        public async Task<IActionResult> DeleteTarifa(int id)
        {
            try
            {
                var result = await _tarifaService.DeleteTarifa(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
