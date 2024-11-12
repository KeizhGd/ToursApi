using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.MovilService
{
    public class MovilServices : IMovilServices
    {
        private readonly ConnectionSLSQLServer _context;

        public MovilServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<MovilModel>>> GetAllMoviles()
        {
            ResponseAPI<List<MovilModel>> response = new ResponseAPI<List<MovilModel>>();

            try
            {
                var moviles = await _context.Moviles.ToListAsync();

                response.Message = "Móviles cargados con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = moviles;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar los móviles.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<MovilModel>> CreateMovil(MovilModel newMovil)
        {
            ResponseAPI<MovilModel> response = new ResponseAPI<MovilModel>();

            try
            {
                _context.Moviles.Add(newMovil);
                await _context.SaveChangesAsync();

                response.Message = "Móvil creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newMovil;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el móvil.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<MovilModel>> UpdateMovil(int id, MovilModel updatedMovil)
        {
            ResponseAPI<MovilModel> response = new ResponseAPI<MovilModel>();

            try
            {
                var existingMovil = await _context.Moviles.FindAsync(id);
                if (existingMovil == null)
                {
                    response.Message = "Móvil no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingMovil.Nombre = updatedMovil.Nombre;
                existingMovil.TipoUnidad = updatedMovil.TipoUnidad;
                existingMovil.Capacidad = updatedMovil.Capacidad;
                existingMovil.Ano = updatedMovil.Ano;
                existingMovil.Placa = updatedMovil.Placa;
                existingMovil.Marca = updatedMovil.Marca;
                existingMovil.Observaciones = updatedMovil.Observaciones;
                existingMovil.Inhabilitado = updatedMovil.Inhabilitado;

                await _context.SaveChangesAsync();

                response.Message = "Móvil actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingMovil;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el móvil.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<MovilModel>> DeleteMovil(int id)
        {
            ResponseAPI<MovilModel> response = new ResponseAPI<MovilModel>();

            try
            {
                var movilToDelete = await _context.Moviles.FindAsync(id);
                if (movilToDelete == null)
                {
                    response.Message = "Móvil no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Moviles.Remove(movilToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Móvil eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el móvil.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
