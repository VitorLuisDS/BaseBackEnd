using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Infrastructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Security
{
    public class ModulePageMap : IEntityTypeConfiguration<ModulePage>
    {
        public void Configure(EntityTypeBuilder<ModulePage> entity)
        {
            string tableName = nameof(ModulePage);

            entity.HasKey(e => new { e.IdModule, e.IdPage});

            entity.ToTable(tableName);

            entity.Property(e => e.IdModule)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdPage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module)
                .WithMany(p => p.ModulePages)
                .HasForeignKey(d => d.IdModule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}__Module");

            entity.HasOne(d => d.Page)
                .WithMany(p => p.ModulePages)
                .HasForeignKey(d => d.IdPage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}__Page");

            BaseMap.Configure(entity, tableName);
        }
    }
}
