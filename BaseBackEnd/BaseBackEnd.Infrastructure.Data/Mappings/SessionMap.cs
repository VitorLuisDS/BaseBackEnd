using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings
{
    public class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> entity)
        {
            string tableName = nameof(Session);

            entity.ToTable(tableName);

            entity.HasKey(e => e.Id)
                .IsClustered();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(NEWID())");

            entity.Property(e => e.StayConnected)
                .HasDefaultValueSql($"(CONVERT([bit],(0)))");

            entity.Property(e => e.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("(GETDATE())");

            entity.Property(e => e.LastModificationDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("(GETDATE())")
                .IsRequired(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_User");

            entity.HasOne(d => d.SessionBlackList)
                .WithOne(p => p.Session)
                .HasForeignKey<Session>(d => d.IdSessionBlackList)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_SessionBlackList")
                .IsRequired(false);
        }
    }
}
