using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Infrastructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Security
{
    public class ProfileModulePageFunctionalityMap : IEntityTypeConfiguration<ProfileModulePageFunctionality>
    {
        public void Configure(EntityTypeBuilder<ProfileModulePageFunctionality> entity)
        {
            string tabelaNome = nameof(ProfileModulePageFunctionality);

            entity.ToTable(tabelaNome);

            entity.HasKey(e => new { e.IdProfile, e.IdModule, e.IdPage, e.IdFunctionality });

            entity.Property(e => e.IdModule)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdPage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdFunctionality)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Profile)
                .WithMany(p => p.ProfileModulePageFunctionalities)
                .HasForeignKey(d => d.IdProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tabelaNome}_Profile");

            entity.HasOne(d => d.ModulePageFunctionality)
                .WithMany(p => p.ProfileModulePageFunctionalities)
                .HasForeignKey(d => new { d.IdModule, d.IdPage, d.IdFunctionality })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tabelaNome}__ModulePageFunctionality");

            BaseMap.Configure(entity, tabelaNome);
        }
    }
}
