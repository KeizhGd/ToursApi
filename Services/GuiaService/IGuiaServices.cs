using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.GuiaService
{
    public interface IGuiaServices
    {
        Task<ResponseAPI<List<GuiaModel>>> GetAllGuias();
        Task<ResponseAPI<GuiaModel>> CreateGuia(GuiaModel newGuia);
        Task<ResponseAPI<GuiaModel>> UpdateGuia(int id, GuiaModel updatedGuia);
        Task<ResponseAPI<GuiaModel>> DeleteGuia(int id);
    }
}
