using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.ServicioService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioServices _servicioService;

        public ServicioController(IServicioServices servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        [Route("GetAllServicios")]
        public async Task<IActionResult> GetAllServicios()
        {
            try
            {
                var result = await _servicioService.GetAllServicios();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateServicio")]
        public async Task<IActionResult> CreateServicio([FromBody] ServicioModel newServicio)
        {
            try
            {
                var result = await _servicioService.CreateServicio(newServicio);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateServicio/{id}")]
        public async Task<IActionResult> UpdateServicio(int id, [FromBody] ServicioModel updatedServicio)
        {
            try
            {
                var result = await _servicioService.UpdateServicio(id, updatedServicio);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteServicio/{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            try
            {
                var result = await _servicioService.DeleteServicio(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
