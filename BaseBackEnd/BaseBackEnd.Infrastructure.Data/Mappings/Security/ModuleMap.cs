using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Infrastructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Security
{
    public class ModuleMap : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> entity)
        {
            string tabelaNome = nameof(Module);

            entity.ToTable(tabelaNome);

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(NEWID())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasIndex(e => e.Name, $"UN_{tabelaNome}_Name")
                .IsUnique();

            BaseMap.Configure(entity, tabelaNome);
        }
    }
}
