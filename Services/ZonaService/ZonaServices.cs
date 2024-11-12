using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slothlandapi.Services.ZonaService
{
    public class ZonaServices : IZonaServices
    {
        private readonly ConnectionSLSQLServer _context;

        public ZonaServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<ZonaModel>>> GetAllZonas()
        {
            ResponseAPI<List<ZonaModel>> response = new ResponseAPI<List<ZonaModel>>();

            try
            {
                var zonas = await _context.Zona.ToListAsync();

                response.Message = "Zonas cargadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = zonas;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar las zonas.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ZonaModel>> GetZonaById(long id)
        {
            ResponseAPI<ZonaModel> response = new ResponseAPI<ZonaModel>();

            try
            {
                var zona = await _context.Zona.FindAsync(id);

                if (zona == null)
                {
                    response.Message = "Zona no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                response.Message = "Zona cargada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = zona;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar la zona.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ZonaModel>> CreateZona(ZonaModel newZona)
        {
            ResponseAPI<ZonaModel> response = new ResponseAPI<ZonaModel>();

            try
            {
                _context.Zona.Add(newZona);
                await _context.SaveChangesAsync();

                response.Message = "Zona creada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newZona;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear la zona.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ZonaModel>> UpdateZona(long id, ZonaModel updatedZona)
        {
            ResponseAPI<ZonaModel> response = new ResponseAPI<ZonaModel>();

            try
            {
                var existingZona = await _context.Zona.FindAsync(id);
                if (existingZona == null)
                {
                    response.Message = "Zona no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingZona.Nombre = updatedZona.Nombre;
                existingZona.Direccion = updatedZona.Direccion;
                existingZona.CodigoPostal = updatedZona.CodigoPostal;
                existingZona.Observaciones = updatedZona.Observaciones;
                existingZona.Inhabilitado = updatedZona.Inhabilitado;

                await _context.SaveChangesAsync();

                response.Message = "Zona actualizada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingZona;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar la zona.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ZonaModel>> DeleteZona(long id)
        {
            ResponseAPI<ZonaModel> response = new ResponseAPI<ZonaModel>();

            try
            {
                var zonaToDelete = await _context.Zona.FindAsync(id);
                if (zonaToDelete == null)
                {
                    response.Message = "Zona no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Zona.Remove(zonaToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Zona eliminada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar la zona.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
