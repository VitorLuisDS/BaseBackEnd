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

            entity.HasKey(e => new { e.IdModulePage, e.IdPage, e.IdFunctionality });

            entity.Property(e => e.IdModulePage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdPage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdFunctionality)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Functionality)
                .WithMany(p => p.ModulePageFunctionalities)
                .HasForeignKey(d => d.IdFunctionality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}__Functionality");

            entity.HasOne(d => d.ModulePage)
                .WithMany(p => p.ModulePageFunctionalities)
                .HasForeignKey(d => new { d.IdModulePage, d.IdPage })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}__Module_Page");

            BaseMap.Configure(entity, tableName);
        }
    }
}
