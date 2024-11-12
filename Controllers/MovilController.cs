using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.MovilService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class MovilController : ControllerBase
    {
        private readonly IMovilServices _movilService;

        public MovilController(IMovilServices movilService)
        {
            _movilService = movilService;
        }

        [HttpGet]
        [Route("[controller]/GetAllMoviles")]
        public async Task<IActionResult> GetAllMoviles()
        {
            try
            {
                var moviles = await _movilService.GetAllMoviles();
                return Ok(moviles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[controller]/CreateMovil")]
        public async Task<IActionResult> CreateMovil([FromBody] MovilModel newMovil)
        {
            try
            {
                var response = await _movilService.CreateMovil(newMovil);
                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[controller]/UpdateMovil/{id}")]
        public async Task<IActionResult> UpdateMovil(int id, [FromBody] MovilModel updatedMovil)
        {
            try
            {
                var response = await _movilService.UpdateMovil(id, updatedMovil);
                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[controller]/DeleteMovil/{id}")]
        public async Task<IActionResult> DeleteMovil(int id)
        {
            try
            {
                var response = await _movilService.DeleteMovil(id);
                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
