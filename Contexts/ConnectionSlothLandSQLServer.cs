using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using slothlandapi.Models;

namespace slothlandapi.Contexts
{
    public class ConnectionSLSQLServer : DbContext
    {

        public ConnectionSLSQLServer(DbContextOptions<ConnectionSLSQLServer> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<TourModel> Tour { get; set; }
        public DbSet<DetalleServicioModel> DetalleServicio { get; set; }
        public DbSet<ChoferModel> Chofer { get; set; }
        public DbSet<GuiaModel> Guias { get; set; }
        public DbSet<MovilModel> Moviles { get; set; }
        public DbSet<ServicioModel> Servicio { get; set; }
        public DbSet<TarifaTourModel> TarifaTour { get; set; }
        public DbSet<ZonaModel> Zona { get; set; }
        public DbSet<TourOperatorModel> TourOperator { get; set; }
        public DbSet<TarifaCostoModel> TarifaCosto { get; set; }


    }

}

