using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataPersistence.ModelConfig
{
    public class DetalleFacturaConfig
    {
        public DetalleFacturaConfig(EntityTypeBuilder<DetalleFactura>entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.IdFactura).IsRequired();
            entity.Property(p => p.IdProducto).IsRequired();
            entity.Property(p => p.PrecioActualProducto).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.CantidadProducto).IsRequired();
            entity.Property(p => p.PorcentajeDescuento).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.TotalDescuento).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.SubTotal).IsRequired().HasColumnType("decimal(10,2)");
        }
    }
}
