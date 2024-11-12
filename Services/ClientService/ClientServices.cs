using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using slothlandapi.Contexts;

namespace slothlandapi.Services.ClientService
{
    public class ClientServices : IClientServices
    {
        private readonly ConnectionSQLServer _context;

        public ClientServices(ConnectionSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<ClientModel>>> GetAllClients()
        {
            ResponseAPI<List<ClientModel>> response = new ResponseAPI<List<ClientModel>>();

            try
            {
                var clients = await _context.Clientes.ToListAsync();

                response.Message = "Clientes cargados con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = clients;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar los clientes.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ClientModel>> CreateClient(ClientModel newClient)
        {
            ResponseAPI<ClientModel> response = new ResponseAPI<ClientModel>();

            try
            {
                _context.Clientes.Add(newClient);
                await _context.SaveChangesAsync();

                response.Message = "Cliente creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newClient;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el cliente.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ClientModel>> UpdateClient(long id, ClientModel updatedClient)
        {
            ResponseAPI<ClientModel> response = new ResponseAPI<ClientModel>();

            try
            {
                var existingClient = await _context.Clientes.FindAsync(id);
                if (existingClient == null)
                {
                    response.Message = "Cliente no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                existingClient.nombre = updatedClient.nombre;
                existingClient.cedula = updatedClient.cedula;
                existingClient.TipoID = updatedClient.TipoID;
                existingClient.Telefono_01 = updatedClient.Telefono_01;
                existingClient.e_mail = updatedClient.e_mail;
                existingClient.direccion = updatedClient.direccion;
                existingClient.Contacto = updatedClient.Contacto;
                existingClient.TelefonoContacto = updatedClient.TelefonoContacto;
                existingClient.observaciones = updatedClient.observaciones;

                await _context.SaveChangesAsync();

                response.Message = "Cliente actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingClient;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el cliente.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ClientModel>> DeleteClient(long id)
        {
            ResponseAPI<ClientModel> response = new ResponseAPI<ClientModel>();

            try
            {
                var clientToDelete = await _context.Clientes.FindAsync(id);
                if (clientToDelete == null)
                {
                    response.Message = "Cliente no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Clientes.Remove(clientToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Cliente eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el cliente.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
