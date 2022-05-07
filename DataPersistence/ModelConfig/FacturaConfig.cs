using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataPersistence.ModelConfig
{
    public class FacturaConfig
    {
        public FacturaConfig(EntityTypeBuilder<Factura>entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.NombreCliente).IsRequired().HasMaxLength(1000);
            entity.Property(p => p.SubTotal).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.Total).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.TotalDescuento).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.FechaCreacion).IsRequired();
        }
    }
}
