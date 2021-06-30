using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Infrastructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Security
{
    public class ModulePageFunctionalityMap : IEntityTypeConfiguration<ModulePageFunctionality>
    {
        public void Configure(EntityTypeBuilder<ModulePageFunctionality> entity)
        {
            string tableName = nameof(ModulePageFunctionality);

            entity.ToTable(tableName);

            entity.HasKey(e => new { e.IdModule, e.IdPage, e.IdFunctionality })
                .IsClustered();

            entity.Property(e => e.IdModule);

            entity.Property(e => e.IdPage);

            entity.Property(e => e.IdFunctionality);

            entity.HasOne(d => d.Functionality)
                .WithMany(p => p.ModulePageFunctionalities)
                .HasForeignKey(d => d.IdFunctionality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Functionality");

            entity.HasOne(d => d.ModulePage)
                .WithMany(p => p.ModulePageFunctionalities)
                .HasForeignKey(d => new { d.IdModule, d.IdPage })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Module_Page");

            BaseMap.Configure(entity, tableName);
        }
    }
}
