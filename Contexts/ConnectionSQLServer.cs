
using Microsoft.EntityFrameworkCore;
using slothlandapi.Models;

namespace slothlandapi.Contexts
{
	public class ConnectionSQLServer:DbContext
	{
		public ConnectionSQLServer(DbContextOptions<ConnectionSQLServer> dbContextOptions) : base(dbContextOptions) 
		{

		}

		public DbSet<UserModel> Usuarios { get; set; }
		public DbSet<ClientModel> Clientes { get; set; }
		public DbSet<ProveedoresModel> Proveedores { get; set; }
		public DbSet<HistoryRefreshTokenModel> HistorialRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoryRefreshTokenModel>()
                .Property(t => t.EsActivo)
                .HasComputedColumnSql("CASE WHEN [FechaExpiracion] < GETDATE() THEN 0 ELSE 1 END");
        }

    }
}
