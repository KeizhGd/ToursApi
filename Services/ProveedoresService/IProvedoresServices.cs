using slothlandapi.Models;
using slothlandapi.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slothlandapi.Services.ProveedoresService
{
    public interface IProveedoresServices
    {
        Task<ResponseAPI<List<ProveedoresModel>>> GetAllProveedores();
        Task<ResponseAPI<ProveedoresModel>> CreateProveedor(ProveedoresModel newProveedor);
        Task<ResponseAPI<ProveedoresModel>> UpdateProveedor(int id, ProveedoresModel updatedProveedor);
        Task<ResponseAPI<ProveedoresModel>> DeleteProveedor(int id);
        Task<ResponseAPI<List<ProveedoresModel>>> FilterProveedores(string name);
    }
}
