using DataPersistence.ModelConfig;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.ViewModels;

namespace DataPersistence
{
    public class FacturaContext:DbContext
    {
        public FacturaContext(DbContextOptions<FacturaContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new MarcaConfig(modelBuilder.Entity<Marca>());
            new AutoConfig(modelBuilder.Entity<Auto>());
            new FacturaConfig(modelBuilder.Entity<Factura>());
            new DetalleFacturaConfig(modelBuilder.Entity<DetalleFactura>());
        }

        #region Modelo
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Auto> Auto { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        #endregion

        #region stored procedure
        public DbSet<vmAuto> vmAuto { get; set; }
        #endregion
       
    }
}
