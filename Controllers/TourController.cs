using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.TourService;

namespace slothlandapi.Controllers
{


    [Route("api/")]
    [ApiController]
    [Authorize]
    public class TourController : ControllerBase
    {


        private readonly ITourServices _tourServices;
  
        public TourController(ITourServices its)
        {

            _tourServices = its;
        }

        [HttpGet]
        [Route("[controller]/GetAllTours")]
        
        public async Task<IActionResult> GetAllTours()
        {



            try
            {

                var fl = await _tourServices.GetAllTours();
                return Ok(fl);

            }
            catch (Exception ex)
            { 
                
            return BadRequest(ex.Message);
            }
        }




        [HttpGet]
        [Route("[controller]/TryInfo")]

        public async Task<IActionResult> Tryinfo()
        {

            return Ok("Esta es una Prueba para determinar si puede hacer peticiones Ngrok");

        }


            [HttpPost]
        [Route("[controller]/CreateTour")]
        
        public async Task<IActionResult> CreateTour([FromBody] TourModel newTour)
        {
            try
            {
                var response = await _tourServices.CreateTour(newTour);
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
        [Route("[controller]/UpdateTour/{id}")]
        
        public async Task<IActionResult> UpdateTour(int id, [FromBody] TourModel updatedTour)
        {
            try
            {
                var response = await _tourServices.UpdateTour(id, updatedTour);
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
        [Route("[controller]/DeleteTour/{id}")]
        
        public async Task<IActionResult> DeleteTour(int id)
        {
            try
            {
                var response = await _tourServices.DeleteTour(id);
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

        [HttpGet]
        [Route("[controller]/FilterTours/{name}")]
        
        public async Task<IActionResult> FilterTours(string name)
        {
            try
            {
                var response = await _tourServices.FilterTours(name);
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
