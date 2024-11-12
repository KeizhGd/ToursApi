using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.TarifaCostoService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class TarifaCostoController : ControllerBase
    {
        private readonly ITarifaCostoServices _tarifaCostoService;

        public TarifaCostoController(ITarifaCostoServices tarifaCostoService)
        {
            _tarifaCostoService = tarifaCostoService;
        }

        [HttpGet]
        [Route("[controller]/GetAllTarifaCostos")]
        public async Task<IActionResult> GetAllTarifaCostos()
        {
            try
            {
                var tarifas = await _tarifaCostoService.GetAllTarifaCostos();
                return Ok(tarifas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
        
        [HttpGet]
        [Route("[controller]/GetAllTarifaCostosbyServicio/{id}")]
        public async Task<IActionResult> GetAllTarifaCostosbyServicio(int id)
        {
            try
            {
                var tarifas = await _tarifaCostoService.GetAllTarifaCostosbyServicio(id);
                return Ok(tarifas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[controller]/CreateTarifaCosto")]
        public async Task<IActionResult> CreateTarifaCosto([FromBody] TarifaCostoModel newTarifaCosto)
        {
            try
            {
                var response = await _tarifaCostoService.CreateTarifaCosto(newTarifaCosto);
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
        [Route("[controller]/UpdateTarifaCosto/{id}")]
        public async Task<IActionResult> UpdateTarifaCosto(long id, [FromBody] TarifaCostoModel updatedTarifaCosto)
        {
            try
            {
                var response = await _tarifaCostoService.UpdateTarifaCosto(id, updatedTarifaCosto);
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
        [Route("[controller]/DeleteTarifaCosto/{id}")]
        public async Task<IActionResult> DeleteTarifaCosto(long id)
        {
            try
            {
                var response = await _tarifaCostoService.DeleteTarifaCosto(id);
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
        [Route("[controller]/DeleteTarifaCostosbyServicio/{id}")]
        public async Task<IActionResult> DeleteTarifaCostosbyServicio(long id)
        {
            try
            {
                var response = await _tarifaCostoService.DeleteTarifaCostosbyServicio(id);
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





        [HttpPost]
        [Route("[controller]/CreateTarifasForServicio/{idServicio}")]
        public async Task<IActionResult> CreateTarifasForServicio(int idServicio, [FromBody] List<TarifaCostoModel> tarifas)
        {
            try
            {
                if (tarifas == null || tarifas.Count == 0)
                {
                    return BadRequest("La lista de tarifas no puede estar vacía.");
                }

                var response = await _tarifaCostoService.CreateTarifasForServicio(idServicio, tarifas);

                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







    }
}
