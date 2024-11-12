using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.ClientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientService;

        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var result = await _clientService.GetAllClients();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] ClientModel newClient)
        {
            try
            {
                var result = await _clientService.CreateClient(newClient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateClient/{id}")]
        public async Task<IActionResult> UpdateClient(long id, [FromBody] ClientModel updatedClient)
        {
            try
            {
                var result = await _clientService.UpdateClient(id, updatedClient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            try
            {
                var result = await _clientService.DeleteClient(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
