using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.TarifaTourService
{
    public interface ITarifaTourServices
    {
        Task<ResponseAPI<List<TarifaTourModel>>> GetAllTarifas();
        Task<ResponseAPI<List<TarifaTourModel>>> GetTarifaById(int Id);
        Task<ResponseAPI<TarifaTourModel>> CreateTarifa(TarifaTourModel newTarifa);
        Task<ResponseAPI<TarifaTourModel>> UpdateTarifa(int id, TarifaTourModel updatedTarifa);
        Task<ResponseAPI<TarifaTourModel>> DeleteTarifa(int id);
    }
}
