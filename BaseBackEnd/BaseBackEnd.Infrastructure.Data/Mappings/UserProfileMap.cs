using BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings
{
    public class UserProfileMap : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> entity)
        {
            string tableName = nameof(UserProfile);

            entity.ToTable(tableName);

            entity.HasKey(e => new { e.IdUser, e.IdProfile })
                .IsClustered();

            entity.Property(e => e.IdUser);

            entity.Property(e => e.IdProfile);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_User");

            entity.HasOne(d => d.Profile)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.IdProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Profile");

            BaseMap.Configure(entity, tableName);
        }
    }
}
