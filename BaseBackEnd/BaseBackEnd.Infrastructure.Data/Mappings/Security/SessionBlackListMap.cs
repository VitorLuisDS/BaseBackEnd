using BaseBackEnd.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Security
{
    public class SessionBlackListMap : IEntityTypeConfiguration<SessionBlackList>
    {
        public void Configure(EntityTypeBuilder<SessionBlackList> entity)
        {
            string tableName = nameof(SessionBlackList);

            entity.ToTable(tableName);

            entity.HasKey(e => e.Id)
                .IsClustered();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(NEWID())");

            entity.HasOne(d => d.Session)
                .WithOne(p => p.SessionBlackList)
                .HasForeignKey<SessionBlackList>(d => d.IdSession)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}__Session");
        }
    }
}
