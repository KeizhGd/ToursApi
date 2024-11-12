using Microsoft.EntityFrameworkCore;
using slothlandapi.Contexts;
using slothlandapi.Models;
using slothlandapi.Response;

namespace slothlandapi.Services.ProveedoresService
{
    public class ProveedoresServices : IProveedoresServices
    {
        private readonly ConnectionSQLServer _context;

        public ProveedoresServices(ConnectionSQLServer context)
        {
            _context = context;
        }

        public async Task<ResponseAPI<List<ProveedoresModel>>> GetAllProveedores()
        {
            ResponseAPI<List<ProveedoresModel>> response = new ResponseAPI<List<ProveedoresModel>>();

            try
            {
                var proveedores = await _context.Proveedores.ToListAsync();
                response.Message = "Proveedores cargados con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = proveedores;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al cargar los proveedores.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ProveedoresModel>> CreateProveedor(ProveedoresModel newProveedor)
        {
            ResponseAPI<ProveedoresModel> response = new ResponseAPI<ProveedoresModel>();

            try
            {
                _context.Proveedores.Add(newProveedor);
                await _context.SaveChangesAsync();

                response.Message = "Proveedor creado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = newProveedor;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el proveedor.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ProveedoresModel>> UpdateProveedor(int id, ProveedoresModel updatedProveedor)
        {
            ResponseAPI<ProveedoresModel> response = new ResponseAPI<ProveedoresModel>();

            try
            {
                var existingProveedor = await _context.Proveedores.FindAsync(id);
                if (existingProveedor == null)
                {
                    response.Message = "Proveedor no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                // Actualiza las propiedades del proveedor existente, excluyendo el CodigoProv
                existingProveedor.Cedula = updatedProveedor.Cedula;
                existingProveedor.Nombre = updatedProveedor.Nombre;
                existingProveedor.Contacto = updatedProveedor.Contacto;
                existingProveedor.Telefono_Cont = updatedProveedor.Telefono_Cont;
                existingProveedor.Observaciones = updatedProveedor.Observaciones;
                existingProveedor.Telefono1 = updatedProveedor.Telefono1;
                existingProveedor.Telefono2 = updatedProveedor.Telefono2;
                existingProveedor.Fax1 = updatedProveedor.Fax1;
                existingProveedor.Fax2 = updatedProveedor.Fax2;
                existingProveedor.Email = updatedProveedor.Email;
                existingProveedor.Direccion = updatedProveedor.Direccion;
                existingProveedor.MontoCredito = updatedProveedor.MontoCredito;
                existingProveedor.Plazo = updatedProveedor.Plazo;
                existingProveedor.CostoTotal = updatedProveedor.CostoTotal;
                existingProveedor.ImpIncluido = updatedProveedor.ImpIncluido;
                existingProveedor.PedidosMes = updatedProveedor.PedidosMes;
                existingProveedor.Utilidad_Inventario = updatedProveedor.Utilidad_Inventario;
                existingProveedor.Utilidad_Fija = updatedProveedor.Utilidad_Fija;
                existingProveedor.CuentaContable = updatedProveedor.CuentaContable;
                existingProveedor.DescripcionCuentaContable = updatedProveedor.DescripcionCuentaContable;
                existingProveedor.Comisionista = updatedProveedor.Comisionista;
                existingProveedor.Mensajeria = updatedProveedor.Mensajeria;
                existingProveedor.CorreoPedidos = updatedProveedor.CorreoPedidos;
                existingProveedor.DiasVisita = updatedProveedor.DiasVisita;

                await _context.SaveChangesAsync();

                response.Message = "Proveedor actualizado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = existingProveedor;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al actualizar el proveedor.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<ProveedoresModel>> DeleteProveedor(int id)
        {
            ResponseAPI<ProveedoresModel> response = new ResponseAPI<ProveedoresModel>();

            try
            {
                var proveedorToDelete = await _context.Proveedores.FindAsync(id);
                if (proveedorToDelete == null)
                {
                    response.Message = "Proveedor no encontrado.";
                    response.Success = false;
                    response.DataError = "";
                    response.DataResponse = null;

                    return response;
                }

                _context.Proveedores.Remove(proveedorToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Proveedor eliminado con éxito.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = null;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al eliminar el proveedor.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }

        public async Task<ResponseAPI<List<ProveedoresModel>>> FilterProveedores(string name)
        {
            ResponseAPI<List<ProveedoresModel>> response = new ResponseAPI<List<ProveedoresModel>>();

            try
            {
                var proveedores = await _context.Proveedores
                    .Where(p => p.Nombre.ToLower().Contains(name.ToLower()))
                    .ToListAsync();

                response.Message = "Búsqueda de proveedores por nombre completada.";
                response.Success = true;
                response.DataError = "";
                response.DataResponse = proveedores;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al buscar proveedores por nombre.";
                response.Success = false;
                response.DataError = ex.Message;
                response.DataResponse = null;

                return response;
            }
        }
    }
}
