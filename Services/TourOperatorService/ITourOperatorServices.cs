using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.TourOperatorService
{
    public interface ITourOperatorServices
    {
        Task<ResponseAPI<List<TourOperatorModel>>> GetAllTourOperators();
        Task<ResponseAPI<TourOperatorModel>> CreateTourOperator(TourOperatorModel newTourOperator);
        Task<ResponseAPI<TourOperatorModel>> UpdateTourOperator(long id, TourOperatorModel updatedTourOperator);
        Task<ResponseAPI<TourOperatorModel>> DeleteTourOperator(long id);
    }
}
