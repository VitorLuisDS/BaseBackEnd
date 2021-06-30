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

            entity.HasKey(e => new { e.IdProfile, e.IdModule, e.IdPage, e.IdFunctionality })
                .IsClustered();

            entity.Property(e => e.IdModule);

            entity.Property(e => e.IdPage);

            entity.Property(e => e.IdFunctionality);

            entity.HasOne(d => d.Profile)
                .WithMany(p => p.ProfileModulePageFunctionalities)
                .HasForeignKey(d => d.IdProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tabelaNome}_Profile");

            entity.HasOne(d => d.ModulePageFunctionality)
                .WithMany(p => p.ProfileModulePageFunctionalities)
                .HasForeignKey(d => new { d.IdModule, d.IdPage, d.IdFunctionality })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tabelaNome}_ModulePageFunctionality");

            BaseMap.Configure(entity, tabelaNome);
        }
    }
}
