using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.GuiaService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GuiaController : ControllerBase
    {
        private readonly IGuiaServices _guiaService;

        public GuiaController(IGuiaServices guiaService)
        {
            _guiaService = guiaService;
        }

        [HttpGet]
        [Route("GetAllGuias")]
        public async Task<IActionResult> GetAllGuias()
        {
            try
            {
                var result = await _guiaService.GetAllGuias();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateGuia")]
        public async Task<IActionResult> CreateGuia([FromBody] GuiaModel newGuia)
        {
            try
            {
                var result = await _guiaService.CreateGuia(newGuia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateGuia/{id}")]
        public async Task<IActionResult> UpdateGuia(int id, [FromBody] GuiaModel updatedGuia)
        {
            try
            {
                var result = await _guiaService.UpdateGuia(id, updatedGuia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteGuia/{id}")]
        public async Task<IActionResult> DeleteGuia(int id)
        {
            try
            {
                var result = await _guiaService.DeleteGuia(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
