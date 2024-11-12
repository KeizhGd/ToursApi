using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.ZonaService
{
    public interface IZonaServices
    {
        Task<ResponseAPI<List<ZonaModel>>> GetAllZonas();
        Task<ResponseAPI<ZonaModel>> GetZonaById(long id);
        Task<ResponseAPI<ZonaModel>> CreateZona(ZonaModel newZona);
        Task<ResponseAPI<ZonaModel>> UpdateZona(long id, ZonaModel updatedZona);
        Task<ResponseAPI<ZonaModel>> DeleteZona(long id);
    }
}
