using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.ChoferService
{
    public interface IChoferServices
    {
        Task<ResponseAPI<List<ChoferModel>>> GetAllChoferes();
        Task<ResponseAPI<ChoferModel>> CreateChofer(ChoferModel newChofer);
        Task<ResponseAPI<ChoferModel>> UpdateChofer(int id, ChoferModel updatedChofer);
        Task<ResponseAPI<ChoferModel>> DeleteChofer(int id);
    }
}
