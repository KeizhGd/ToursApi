using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.TarifaCostoService
{
    public class TarifaCostoServices : ITarifaCostoServices
    {
        private readonly ConnectionSLSQLServer _context;

        public TarifaCostoServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<TarifaCostoModel>>> GetAllTarifaCostos()
        {
            ResponseAPI<List<TarifaCostoModel>> response = new ResponseAPI<List<TarifaCostoModel>>();

            try
            {
                var tarifaCostos = await _context.TarifaCosto.ToListAsync();

                response.Message = "Tarifas cargadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tarifaCostos;

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
        
         public async Task<ResponseAPI<List<TarifaCostoModel>>> GetAllTarifaCostosbyServicio(int id)
        {
            ResponseAPI<List<TarifaCostoModel>> response = new ResponseAPI<List<TarifaCostoModel>>();

            try
            {
                var tarifaCostos = await _context.TarifaCosto.Where(ob => ob.IdServicio == id).ToListAsync();

                response.Message = "Tarifas cargadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tarifaCostos;

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

        public async Task<ResponseAPI<TarifaCostoModel>> CreateTarifaCosto(TarifaCostoModel newTarifaCosto)
        {
            ResponseAPI<TarifaCostoModel> response = new ResponseAPI<TarifaCostoModel>();

            try
            {
                _context.TarifaCosto.Add(newTarifaCosto);
                await _context.SaveChangesAsync();

                response.Message = "Tarifa creada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newTarifaCosto;

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

        public async Task<ResponseAPI<TarifaCostoModel>> UpdateTarifaCosto(long id, TarifaCostoModel updatedTarifaCosto)
        {
            ResponseAPI<TarifaCostoModel> response = new ResponseAPI<TarifaCostoModel>();

            try
            {
                var existingTarifaCosto = await _context.TarifaCosto.FindAsync(id);
                if (existingTarifaCosto == null)
                {
                    response.Message = "Tarifa no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingTarifaCosto.IdProveedor = updatedTarifaCosto.IdProveedor;
                existingTarifaCosto.NombreProveedor = updatedTarifaCosto.NombreProveedor;
                existingTarifaCosto.Principal = updatedTarifaCosto.Principal;
                existingTarifaCosto.IdServicio = updatedTarifaCosto.IdServicio;
                existingTarifaCosto.NombreServicio = updatedTarifaCosto.NombreServicio;
                existingTarifaCosto.PrecioCostoAdulto = updatedTarifaCosto.PrecioCostoAdulto;
                existingTarifaCosto.PrecioCostoNino = updatedTarifaCosto.PrecioCostoNino;

                await _context.SaveChangesAsync();

                response.Message = "Tarifa actualizada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingTarifaCosto;

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

        public async Task<ResponseAPI<TarifaCostoModel>> DeleteTarifaCosto(long id)
        {
            ResponseAPI<TarifaCostoModel> response = new ResponseAPI<TarifaCostoModel>();

            try
            {
                var tarifaCostoToDelete = await _context.TarifaCosto.FindAsync(id);
                if (tarifaCostoToDelete == null)
                {
                    response.Message = "Tarifa no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.TarifaCosto.Remove(tarifaCostoToDelete);
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

        public async Task<ResponseAPI<TarifaCostoModel>> DeleteTarifaCostosbyServicio(long id)
        {
            ResponseAPI<TarifaCostoModel> response = new ResponseAPI<TarifaCostoModel>();

            try
            {
                // Obtener los registros a eliminar
                var tarifaCostoToDelete = await _context.TarifaCosto
                    .Where(ob => ob.IdServicio == id)
                    .ToListAsync();

                if (tarifaCostoToDelete == null || !tarifaCostoToDelete.Any())
                {
                    response.Message = "Tarifa no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                // Eliminar los registros
                _context.TarifaCosto.RemoveRange(tarifaCostoToDelete);
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





        public async Task<ResponseAPI<List<TarifaCostoModel>>> CreateTarifasForServicio(int idServicio, List<TarifaCostoModel> tarifas)
        {
            ResponseAPI<List<TarifaCostoModel>> response = new ResponseAPI<List<TarifaCostoModel>>();

            try
            {
                var servicio = await _context.Servicio.FindAsync(idServicio);
                if (servicio == null)
                {
                    response.Message = "Servicio no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;
                    return response;
                }

                foreach (var tarifa in tarifas)
                {
                    tarifa.IdServicio = idServicio;
                    tarifa.NombreServicio = servicio.Nombre;
                }

                _context.TarifaCosto.AddRange(tarifas);
                await _context.SaveChangesAsync();

                response.Message = "Tarifas creadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tarifas;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear las tarifas.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

















    }
}
