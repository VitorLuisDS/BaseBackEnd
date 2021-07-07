using BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Security
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            string tableName = nameof(User);

            entity.ToTable(tableName);

            entity.HasKey(e => e.Id)
                .IsClustered();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);

            entity.HasOne(d => d.Department)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName($"FK_{tableName}_Department");

            entity.HasIndex(e => e.Login, $"UN_{tableName}_Login")
                .IsUnique();

            BaseMap.Configure(entity, tableName);
        }
    }
}