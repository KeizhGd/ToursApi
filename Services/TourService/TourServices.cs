using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;

namespace slothlandapi.Services.TourService
{
    public class TourServices: ITourServices
    {

        private readonly ConnectionSLSQLServer _context;

    
        public TourServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }


        public async Task<ResponseAPI<List<TourModel>>> GetAllTours()
        {

            ResponseAPI<List<TourModel>> response = new ResponseAPI<List<TourModel>>();


            List<TourModel> tours = new List<TourModel>();



            try
            {
                tours = await _context.Tour.ToListAsync();

                response.Message="Tours cargados con éxito. ";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tours;


                return response;
            }
            catch (Exception ex)
            {

                tours = await _context.Tour.ToListAsync();

                response.Message= "Error al cargar los tours. ";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }





        }


        public async Task<ResponseAPI<TourModel>> CreateTour(TourModel newTour)
        {
            ResponseAPI<TourModel> response = new ResponseAPI<TourModel>();

            try
            {
                _context.Tour.Add(newTour);
                await _context.SaveChangesAsync();

                response.Message = "Tour creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newTour;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el tour.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<TourModel>> UpdateTour(int id, TourModel updatedTour)
        {
            ResponseAPI<TourModel> response = new ResponseAPI<TourModel>();

            try
            {
                var existingTour = await _context.Tour.FindAsync(id);
                if (existingTour == null)
                {
                    response.Message = "Tour no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                // Actualiza las propiedades del tour existente, excluyendo el Id
                existingTour.Nombre = updatedTour.Nombre;
                existingTour.Duracion = updatedTour.Duracion;
                existingTour.Direccion = updatedTour.Direccion;
                existingTour.Capacidad = updatedTour.Capacidad;

                await _context.SaveChangesAsync();

                response.Message = "Tour actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingTour;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el tour.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<TourModel>> DeleteTour(int id)
        {
            ResponseAPI<TourModel> response = new ResponseAPI<TourModel>();

            try
            {
                var tourToDelete = await _context.Tour.FindAsync(id);
                if (tourToDelete == null)
                {
                    response.Message = "Tour no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Tour.Remove(tourToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Tour eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el tour.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }





        public async Task<ResponseAPI<List<TourModel>>> FilterTours(string name)
        {
            ResponseAPI<List<TourModel>> response = new ResponseAPI<List<TourModel>>();

            try
            {
                // Busca los tours que contengan el nombre especificado (ignorando mayúsculas y minúsculas)
                var tours = await _context.Tour.Where(t => t.Nombre.ToLower().Contains(name.ToLower())).ToListAsync();

                response.Message = "Búsqueda de tours por nombre completada.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = tours;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al buscar tours por nombre.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }


    }
}
