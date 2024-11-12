using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;

namespace slothlandapi.Services.GuiaService
{
    public class GuiaServices : IGuiaServices
    {
        private readonly ConnectionSLSQLServer _context;

        public GuiaServices(ConnectionSLSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<GuiaModel>>> GetAllGuias()
        {
            ResponseAPI<List<GuiaModel>> response = new ResponseAPI<List<GuiaModel>>();

            try
            {
                List<GuiaModel> guias = await _context.Guias.
                    
                    
                    ToListAsync();

                response.Message = "Guías cargadas con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = guias;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar las guías.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<GuiaModel>> CreateGuia(GuiaModel newGuia)
        {
            ResponseAPI<GuiaModel> response = new ResponseAPI<GuiaModel>();

            try
            {
                _context.Guias.Add(newGuia);
                await _context.SaveChangesAsync();

                response.Message = "Guía creada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newGuia;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear la guía.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<GuiaModel>> UpdateGuia(int id, GuiaModel updatedGuia)
        {
            ResponseAPI<GuiaModel> response = new ResponseAPI<GuiaModel>();

            try
            {
                var existingGuia = await _context.Guias.FindAsync(id);
                if (existingGuia == null)
                {
                    response.Message = "Guía no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                // Actualiza las propiedades de la guía existente, excluyendo el Id
                existingGuia.Nombre = updatedGuia.Nombre;
                existingGuia.CedulaPasaporte = updatedGuia.CedulaPasaporte;
                existingGuia.Edad = updatedGuia.Edad;
                existingGuia.Licencia = updatedGuia.Licencia;
                existingGuia.Celular = updatedGuia.Celular;
                existingGuia.Correo = updatedGuia.Correo;
                existingGuia.Certificado = updatedGuia.Certificado;
                existingGuia.NumeroCarnet = updatedGuia.NumeroCarnet;
                existingGuia.Direccion = updatedGuia.Direccion;
                existingGuia.Observaciones = updatedGuia.Observaciones;
                existingGuia.Inhabilitado = updatedGuia.Inhabilitado;

                await _context.SaveChangesAsync();

                response.Message = "Guía actualizada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingGuia;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar la guía.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<GuiaModel>> DeleteGuia(int id)
        {
            ResponseAPI<GuiaModel> response = new ResponseAPI<GuiaModel>();

            try
            {
                var guiaToDelete = await _context.Guias.FindAsync(id);
                if (guiaToDelete == null)
                {
                    response.Message = "Guía no encontrada.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Guias.Remove(guiaToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Guía eliminada con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar la guía.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<List<GuiaModel>>> FilterGuias(string name)
        {
            ResponseAPI<List<GuiaModel>> response = new ResponseAPI<List<GuiaModel>>();

            try
            {
                // Busca las guías que contengan el nombre especificado (ignorando mayúsculas y minúsculas)
                var guias = await _context.Guias.Where(g => g.Nombre.ToLower().Contains(name.ToLower())).ToListAsync();

                response.Message = "Búsqueda de guías por nombre completada.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = guias;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al buscar guías por nombre.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
