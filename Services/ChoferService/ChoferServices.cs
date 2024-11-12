using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.ChoferService
{
    public class ChoferServices : IChoferServices
    {
        private readonly ConnectionSLSQLServer _context;

        public ChoferServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<ChoferModel>>> GetAllChoferes()
        {
            ResponseAPI<List<ChoferModel>> response = new ResponseAPI<List<ChoferModel>>();

            try
            {
                var choferes = await _context.Chofer.ToListAsync();

                response.Message = "Choferes cargados con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = choferes;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar los choferes.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ChoferModel>> CreateChofer(ChoferModel newChofer)
        {
            ResponseAPI<ChoferModel> response = new ResponseAPI<ChoferModel>();

            try
            {
                _context.Chofer.Add(newChofer);
                await _context.SaveChangesAsync();

                response.Message = "Chofer creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newChofer;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el chofer.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ChoferModel>> UpdateChofer(int id, ChoferModel updatedChofer)
        {
            ResponseAPI<ChoferModel> response = new ResponseAPI<ChoferModel>();

            try
            {
                var existingChofer = await _context.Chofer.FindAsync(id);
                if (existingChofer == null)
                {
                    response.Message = "Chofer no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingChofer.Nombre = updatedChofer.Nombre;
                existingChofer.TipoLicencia = updatedChofer.TipoLicencia;
                existingChofer.VencimientoLicencia = updatedChofer.VencimientoLicencia;
                existingChofer.Celular = updatedChofer.Celular;
                existingChofer.Correo = updatedChofer.Correo;
                existingChofer.Direccion = updatedChofer.Direccion;
                existingChofer.Observaciones = updatedChofer.Observaciones;
                existingChofer.Inhabilitado = updatedChofer.Inhabilitado;

                await _context.SaveChangesAsync();

                response.Message = "Chofer actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingChofer;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el chofer.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ChoferModel>> DeleteChofer(int id)
        {
            ResponseAPI<ChoferModel> response = new ResponseAPI<ChoferModel>();

            try
            {
                var choferToDelete = await _context.Chofer.FindAsync(id);
                if (choferToDelete == null)
                {
                    response.Message = "Chofer no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Chofer.Remove(choferToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Chofer eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el chofer.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
