using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.ChoferService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]

    public class ChoferController : ControllerBase
    {
        private readonly IChoferServices _choferService;

        public ChoferController(IChoferServices choferService)
        {
            _choferService = choferService;
        }

        [HttpGet]
        [Route("GetAllChoferes")]
        public async Task<IActionResult> GetAllChoferes()
        {
            try
            {
                var result = await _choferService.GetAllChoferes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateChofer")]
        public async Task<IActionResult> CreateChofer([FromBody] ChoferModel newChofer)
        {
            try
            {
                var result = await _choferService.CreateChofer(newChofer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateChofer/{id}")]
        public async Task<IActionResult> UpdateChofer(int id, [FromBody] ChoferModel updatedChofer)
        {
            try
            {
                var result = await _choferService.UpdateChofer(id, updatedChofer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteChofer/{id}")]
        public async Task<IActionResult> DeleteChofer(int id)
        {
            try
            {
                var result = await _choferService.DeleteChofer(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
