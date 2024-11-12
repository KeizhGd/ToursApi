using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.TourOperatorService;
using System;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class TourOperatorController : ControllerBase
    {
        private readonly ITourOperatorServices _tourOperatorService;

        public TourOperatorController(ITourOperatorServices tourOperatorService)
        {
            _tourOperatorService = tourOperatorService;
        }

        [HttpGet]
        [Route("[controller]/GetAllTourOperators")]
        public async Task<IActionResult> GetAllTourOperators()
        {
            try
            {
                var tourOperators = await _tourOperatorService.GetAllTourOperators();
                return Ok(tourOperators);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[controller]/CreateTourOperator")]
        public async Task<IActionResult> CreateTourOperator([FromBody] TourOperatorModel newTourOperator)
        {
            try
            {
                var response = await _tourOperatorService.CreateTourOperator(newTourOperator);
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
        [Route("[controller]/UpdateTourOperator/{id}")]
        public async Task<IActionResult> UpdateTourOperator(long id, [FromBody] TourOperatorModel updatedTourOperator)
        {
            try
            {
                var response = await _tourOperatorService.UpdateTourOperator(id, updatedTourOperator);
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
        [Route("[controller]/DeleteTourOperator/{id}")]
        public async Task<IActionResult> DeleteTourOperator(long id)
        {
            try
            {
                var response = await _tourOperatorService.DeleteTourOperator(id);
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
