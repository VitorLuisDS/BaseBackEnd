using BaseBackEnd.Domain.Entities.Base;
using BaseBackEnd.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Infrastructure.Data.Mappings.Base
{
    public static class BaseMap
    {
        public static void Configure<TEntity>(EntityTypeBuilder<TEntity> entity, string tableName) where TEntity : class
        {
            Configure(entity, tableName, new ConfigBaseMap() { CreationUserIsRequired = true, HasStatusField = true });
        }

        public static void Configure<TEntity>(EntityTypeBuilder<TEntity> entity, string tableName, ConfigBaseMap configBaseMap) where TEntity : class
        {

            if (configBaseMap.HasStatusField)
            {
                entity.Property(nameof(EntityAuditStatusBase.Status))
                    .HasDefaultValueSql($"(CONVERT([bit],({(int)StatusBase.Active})))")
                    .HasComment($"Status of {tableName}. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");
                entity.HasIndex("Status");
            }

            entity.Property(nameof(EntityAuditBase.CreationDate))
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("(GETDATE())");

            entity.Property(nameof(EntityAuditBase.IdCreationUser))
                .HasColumnName(nameof(EntityAuditBase.IdCreationUser))
                .IsRequired(configBaseMap.CreationUserIsRequired);

            entity.Property(nameof(EntityAuditBase.LastModificationDate))
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("(GETDATE())")
                .IsRequired(false);

            entity.Property(nameof(EntityAuditBase.IdLastModificationUser))
                .HasColumnName(nameof(EntityAuditBase.IdLastModificationUser))
                .IsRequired(false);

            entity.HasOne(nameof(EntityAuditBase.CreationUser))
                .WithMany()
                .HasForeignKey(nameof(EntityAuditBase.IdCreationUser))
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Creation_User");

            entity.HasOne(nameof(EntityAuditBase.LastModificationUser))
                .WithMany()
                .HasForeignKey(nameof(EntityAuditBase.IdLastModificationUser))
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Last_Modification_User");
        }
    }

    public class ConfigBaseMap
    {
        public bool HasStatusField { get; set; } = true;
        public bool CreationUserIsRequired { get; set; } = true;
    }
}
