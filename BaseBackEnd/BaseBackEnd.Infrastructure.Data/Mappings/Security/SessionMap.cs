using BaseBackEnd.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Security
{
    public class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> entity)
        {
            string tableName = nameof(Session);

            entity.ToTable(tableName);

            entity.HasKey(e => e.Id);

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
                .HasConstraintName($"FK_${tableName}__User");
        }
    }
}
