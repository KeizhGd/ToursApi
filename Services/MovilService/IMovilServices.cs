using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.MovilService
{
    public interface IMovilServices
    {
        Task<ResponseAPI<List<MovilModel>>> GetAllMoviles();
        Task<ResponseAPI<MovilModel>> CreateMovil(MovilModel newMovil);
        Task<ResponseAPI<MovilModel>> UpdateMovil(int id, MovilModel updatedMovil);
        Task<ResponseAPI<MovilModel>> DeleteMovil(int id);
    }
}
