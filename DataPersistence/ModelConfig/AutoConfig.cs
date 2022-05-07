using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataPersistence.ModelConfig
{
    public class AutoConfig
    {
        public AutoConfig(EntityTypeBuilder<Auto> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.IdMarca);
            entity.Property(p => p.NombreAuto).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Annio).IsRequired();
            entity.Property(p => p.Precio).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.Existencia).IsRequired();
        }
    }
}
