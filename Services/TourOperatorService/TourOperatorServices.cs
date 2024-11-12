using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.TourOperatorService
{
    public class TourOperatorServices : ITourOperatorServices
    {
        private readonly ConnectionSLSQLServer _context;

        public TourOperatorServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<TourOperatorModel>>> GetAllTourOperators()
        {
            ResponseAPI<List<TourOperatorModel>> response = new ResponseAPI<List<TourOperatorModel>>();

            try
            {
                var tourOperators = await _context.TourOperator.ToListAsync();

                response.Message = "Tour Operators cargados con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tourOperators;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar los Tour Operators.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<TourOperatorModel>> CreateTourOperator(TourOperatorModel newTourOperator)
        {
            ResponseAPI<TourOperatorModel> response = new ResponseAPI<TourOperatorModel>();

            try
            {
                _context.TourOperator.Add(newTourOperator);
                await _context.SaveChangesAsync();

                response.Message = "Tour Operator creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newTourOperator;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el Tour Operator.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<TourOperatorModel>> UpdateTourOperator(long id, TourOperatorModel updatedTourOperator)
        {
            ResponseAPI<TourOperatorModel> response = new ResponseAPI<TourOperatorModel>();

            try
            {
                var existingTourOperator = await _context.TourOperator.FindAsync(id);
                if (existingTourOperator == null)
                {
                    response.Message = "Tour Operator no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingTourOperator.IdCliente = updatedTourOperator.IdCliente;
                existingTourOperator.NombreCliente = updatedTourOperator.NombreCliente;
                existingTourOperator.IdTour = updatedTourOperator.IdTour;
                existingTourOperator.NombreTour = updatedTourOperator.NombreTour;
                existingTourOperator.IdZona = updatedTourOperator.IdZona;
                existingTourOperator.NombreZona = updatedTourOperator.NombreZona;
                existingTourOperator.Adultos = updatedTourOperator.Adultos;
                existingTourOperator.Ninos = updatedTourOperator.Ninos;
                existingTourOperator.Documento = updatedTourOperator.Documento;
                existingTourOperator.IdMovil = updatedTourOperator.IdMovil;
                existingTourOperator.NombreMovil = updatedTourOperator.NombreMovil;
                existingTourOperator.IdGuia1 = updatedTourOperator.IdGuia1;
                existingTourOperator.NombreGuia1 = updatedTourOperator.NombreGuia1;
                existingTourOperator.IdGuia2 = updatedTourOperator.IdGuia2;
                existingTourOperator.NombreGuia2 = updatedTourOperator.NombreGuia2;
                existingTourOperator.IdTarifa = updatedTourOperator.IdTarifa;
                existingTourOperator.NombreTarifa = updatedTourOperator.NombreTarifa;
                existingTourOperator.GastosExtra = updatedTourOperator.GastosExtra;
                existingTourOperator.Ingreso = updatedTourOperator.Ingreso;
                existingTourOperator.TieneTransporte = updatedTourOperator.TieneTransporte;
                existingTourOperator.MontoTransporte = updatedTourOperator.MontoTransporte;
                existingTourOperator.MontoParque = updatedTourOperator.MontoParque;
                existingTourOperator.MontoLaCabana = updatedTourOperator.MontoLaCabana;
                existingTourOperator.MontoGuia = updatedTourOperator.MontoGuia;
                existingTourOperator.GastosExtras = updatedTourOperator.GastosExtras;
                existingTourOperator.TotalGasto = updatedTourOperator.TotalGasto;
                existingTourOperator.UtilidadColones = updatedTourOperator.UtilidadColones;
                existingTourOperator.UtilidadDolares = updatedTourOperator.UtilidadDolares;

                await _context.SaveChangesAsync();

                response.Message = "Tour Operator actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingTourOperator;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el Tour Operator.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<TourOperatorModel>> DeleteTourOperator(long id)
        {
            ResponseAPI<TourOperatorModel> response = new ResponseAPI<TourOperatorModel>();

            try
            {
                var tourOperatorToDelete = await _context.TourOperator.FindAsync(id);
                if (tourOperatorToDelete == null)
                {
                    response.Message = "Tour Operator no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.TourOperator.Remove(tourOperatorToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Tour Operator eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el Tour Operator.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
