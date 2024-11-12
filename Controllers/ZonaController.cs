using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.ZonaService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaServices _zonaService;

        public ZonaController(IZonaServices zonaService)
        {
            _zonaService = zonaService;
        }

        [HttpGet]
        [Route("GetAllZonas")]
        public async Task<IActionResult> GetAllZonas()
        {
            try
            {
                var result = await _zonaService.GetAllZonas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetZonaById/{id}")]
        public async Task<IActionResult> GetZonaById(long id)
        {
            try
            {
                var result = await _zonaService.GetZonaById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateZona")]
        public async Task<IActionResult> CreateZona([FromBody] ZonaModel newZona)
        {
            try
            {
                var result = await _zonaService.CreateZona(newZona);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateZona/{id}")]
        public async Task<IActionResult> UpdateZona(long id, [FromBody] ZonaModel updatedZona)
        {
            try
            {
                var result = await _zonaService.UpdateZona(id, updatedZona);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteZona/{id}")]
        public async Task<IActionResult> DeleteZona(long id)
        {
            try
            {
                var result = await _zonaService.DeleteZona(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
