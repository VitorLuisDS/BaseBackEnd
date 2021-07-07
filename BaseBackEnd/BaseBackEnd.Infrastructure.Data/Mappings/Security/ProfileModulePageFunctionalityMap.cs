using BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Security
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
