using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.ServicioService
{
    public class ServicioServices : IServicioServices
    {
        private readonly ConnectionSLSQLServer _context;

        public ServicioServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<ServicioModel>>> GetAllServicios()
        {
            ResponseAPI<List<ServicioModel>> response = new ResponseAPI<List<ServicioModel>>();

            try
            {
                var servicios = await _context.Servicio.ToListAsync();

                response.Message = "Servicios cargados con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = servicios;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar los servicios.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ServicioModel>> CreateServicio(ServicioModel newServicio)
        {
            ResponseAPI<ServicioModel> response = new ResponseAPI<ServicioModel>();

            try
            {
                _context.Servicio.Add(newServicio);
                await _context.SaveChangesAsync();


             ServicioModel lastServicio = await _context.Servicio
            .OrderByDescending(s => s.Id)
            .FirstOrDefaultAsync();

                response.Message = "Servicio creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = lastServicio;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el servicio.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ServicioModel>> UpdateServicio(int id, ServicioModel updatedServicio)
        {
            ResponseAPI<ServicioModel> response = new ResponseAPI<ServicioModel>();

            try
            {
                var existingServicio = await _context.Servicio.FindAsync(id);
                if (existingServicio == null)
                {
                    response.Message = "Servicio no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingServicio.Nombre = updatedServicio.Nombre;
                existingServicio.Transporte = updatedServicio.Transporte;
                existingServicio.Capacidad = updatedServicio.Capacidad;
                existingServicio.Observaciones = updatedServicio.Observaciones;
                existingServicio.Inhabilitado = updatedServicio.Inhabilitado;

                await _context.SaveChangesAsync();

                response.Message = "Servicio actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingServicio;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el servicio.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ServicioModel>> DeleteServicio(int id)
        {
            ResponseAPI<ServicioModel> response = new ResponseAPI<ServicioModel>();

            try
            {
                var servicioToDelete = await _context.Servicio.FindAsync(id);
                if (servicioToDelete == null)
                {
                    response.Message = "Servicio no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Servicio.Remove(servicioToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Servicio eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el servicio.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
