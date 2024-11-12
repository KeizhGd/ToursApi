using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.ServicioService
{
    public interface IServicioServices
    {
        Task<ResponseAPI<List<ServicioModel>>> GetAllServicios();
        Task<ResponseAPI<ServicioModel>> CreateServicio(ServicioModel newServicio);
        Task<ResponseAPI<ServicioModel>> UpdateServicio(int id, ServicioModel updatedServicio);
        Task<ResponseAPI<ServicioModel>> DeleteServicio(int id);
    }
}
