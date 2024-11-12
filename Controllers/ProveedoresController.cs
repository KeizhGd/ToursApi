using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Models;
using slothlandapi.Services.ProveedoresService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedoresServices _proveedoresServices;

        public ProveedoresController(IProveedoresServices ips)
        {
            _proveedoresServices = ips;
        }

        [HttpGet]
        [Route("[controller]/GetAllProveedores")]
        public async Task<IActionResult> GetAllProveedores()
        {
            try
            {
                var fl = await _proveedoresServices.GetAllProveedores();
                return Ok(fl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[controller]/CreateProveedor")]
        public async Task<IActionResult> CreateProveedor([FromBody] ProveedoresModel newProveedor)
        {
            try
            {
                var response = await _proveedoresServices.CreateProveedor(newProveedor);
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
        [Route("[controller]/UpdateProveedor/{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, [FromBody] ProveedoresModel updatedProveedor)
        {
            try
            {
                var response = await _proveedoresServices.UpdateProveedor(id, updatedProveedor);
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
        [Route("[controller]/DeleteProveedor/{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            try
            {
                var response = await _proveedoresServices.DeleteProveedor(id);
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
        [Route("[controller]/FilterProveedores/{name}")]
        public async Task<IActionResult> FilterProveedores(string name)
        {
            try
            {
                var response = await _proveedoresServices.FilterProveedores(name);
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
