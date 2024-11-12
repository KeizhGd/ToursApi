using slothlandapi.Dtos.Auth;
using slothlandapi.Models;
using slothlandapi.Response;

namespace slothlandapi.Services.ClientService
{
	public interface IClientServices
	{

        Task<ResponseAPI<List<ClientModel>>> GetAllClients();
        Task<ResponseAPI<ClientModel>> CreateClient(ClientModel newClient);
        Task<ResponseAPI<ClientModel>> UpdateClient(long id, ClientModel updatedClient);
        Task<ResponseAPI<ClientModel>> DeleteClient(long id);
    }
}
