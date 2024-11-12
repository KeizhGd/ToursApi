using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slothlandapi.Services.TarifaTourService
{
    public class TarifaTourServices : ITarifaTourServices
    {
        private readonly ConnectionSLSQLServer _context;

        public TarifaTourServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<TarifaTourModel>>> GetAllTarifas()
        {
            ResponseAPI<List<TarifaTourModel>> response = new ResponseAPI<List<TarifaTourModel>>();

            try
            {
                var tarifas = await _context.TarifaTour.ToListAsync();

                response.Message = "Tarifas cargadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tarifas;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar las tarifas.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<List<TarifaTourModel>>> GetTarifaById(int Id)
        {
            ResponseAPI<List<TarifaTourModel>> response = new ResponseAPI<List<TarifaTourModel>>();

            try
            {
                var tarifas = await _context.TarifaTour
                    .Where(t => t.Id == Id)
                    .ToListAsync();

                response.Message = "Tarifas cargadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tarifas;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar las tarifas.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }


        public async Task<ResponseAPI<TarifaTourModel>> CreateTarifa(TarifaTourModel newTarifa)
        {
            ResponseAPI<TarifaTourModel> response = new ResponseAPI<TarifaTourModel>();

            try
            {
                _context.TarifaTour.Add(newTarifa);
                await _context.SaveChangesAsync();

                response.Message = "Tarifa creada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newTarifa;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear la tarifa.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<TarifaTourModel>> UpdateTarifa(int id, TarifaTourModel updatedTarifa)
        {
            ResponseAPI<TarifaTourModel> response = new ResponseAPI<TarifaTourModel>();

            try
            {
                var existingTarifa = await _context.TarifaTour.FindAsync(id);
                if (existingTarifa == null)
                {
                    response.Message = "Tarifa no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingTarifa.Nombre = updatedTarifa.Nombre;
                existingTarifa.CodigoCliente = updatedTarifa.CodigoCliente;
                existingTarifa.NombreCliente = updatedTarifa.NombreCliente;
                existingTarifa.IdZona = updatedTarifa.IdZona;
                existingTarifa.NombreZona = updatedTarifa.NombreZona;
                existingTarifa.IdTour = updatedTarifa.IdTour;
                existingTarifa.NombreTour = updatedTarifa.NombreTour;
                existingTarifa.TarifaAdulto = updatedTarifa.TarifaAdulto;
                existingTarifa.TarifaNino = updatedTarifa.TarifaNino;
                existingTarifa.Observaciones = updatedTarifa.Observaciones;
                existingTarifa.Inhabilitado = updatedTarifa.Inhabilitado;

                await _context.SaveChangesAsync();

                response.Message = "Tarifa actualizada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingTarifa;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar la tarifa.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }


        public async Task<ResponseAPI<TarifaTourModel>> DeleteTarifa(int id)
        {
            ResponseAPI<TarifaTourModel> response = new ResponseAPI<TarifaTourModel>();

            try
            {
                var tarifaToDelete = await _context.TarifaTour.FindAsync(id);
                if (tarifaToDelete == null)
                {
                    response.Message = "Tarifa no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.TarifaTour.Remove(tarifaToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Tarifa eliminada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar la tarifa.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
