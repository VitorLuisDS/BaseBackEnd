using BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Security
{
    public class ModulePageMap : IEntityTypeConfiguration<ModulePage>
    {
        public void Configure(EntityTypeBuilder<ModulePage> entity)
        {
            string tableName = nameof(ModulePage);

            entity.HasKey(e => new { e.IdModule, e.IdPage })
                .IsClustered();

            entity.ToTable(tableName);

            entity.Property(e => e.IdModule);

            entity.Property(e => e.IdPage);

            entity.HasOne(d => d.Module)
                .WithMany(p => p.ModulePages)
                .HasForeignKey(d => d.IdModule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Module");

            entity.HasOne(d => d.Page)
                .WithMany(p => p.ModulePages)
                .HasForeignKey(d => d.IdPage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Page");

            BaseMap.Configure(entity, tableName);
        }
    }
}
