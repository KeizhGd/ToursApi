using slothlandapi.Response;
using slothlandapi.Models;
namespace slothlandapi.Services.TourService
{
    public interface ITourServices
    {




    

        Task<ResponseAPI<List<TourModel>>> GetAllTours();
        Task<ResponseAPI<TourModel>> CreateTour(TourModel newTour);
        Task<ResponseAPI<TourModel>> UpdateTour(int id, TourModel updatedTour);
        Task<ResponseAPI<TourModel>> DeleteTour(int id);
        Task<ResponseAPI<List<TourModel>>> FilterTours(string name);


    }
}
