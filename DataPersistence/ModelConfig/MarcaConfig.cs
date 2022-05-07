using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataPersistence.ModelConfig
{
    public class MarcaConfig
    {
        public MarcaConfig(EntityTypeBuilder<Marca> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.NombreMarca).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Borrado).IsRequired();
        }
    }
}
