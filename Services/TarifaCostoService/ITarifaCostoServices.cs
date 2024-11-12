using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.TarifaCostoService
{
    public interface ITarifaCostoServices
    {
        Task<ResponseAPI<List<TarifaCostoModel>>> GetAllTarifaCostos();
        Task<ResponseAPI<List<TarifaCostoModel>>> GetAllTarifaCostosbyServicio(int id);
        Task<ResponseAPI<TarifaCostoModel>> CreateTarifaCosto(TarifaCostoModel newTarifaCosto);
        Task<ResponseAPI<TarifaCostoModel>> UpdateTarifaCosto(long id, TarifaCostoModel updatedTarifaCosto);
        Task<ResponseAPI<TarifaCostoModel>> DeleteTarifaCosto(long id);
        Task<ResponseAPI<TarifaCostoModel>> DeleteTarifaCostosbyServicio(long id);
        Task<ResponseAPI<List<TarifaCostoModel>>> CreateTarifasForServicio(int idServicio, List<TarifaCostoModel> tarifas);

    }
}
