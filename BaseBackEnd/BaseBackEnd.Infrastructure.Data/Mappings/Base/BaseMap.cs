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
                entity.Property("Status")
                    .HasDefaultValueSql($"(CONVERT([bit],({(int)StatusBase.Active})))")
                    .HasComment($"Status of {tableName}. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");
                entity.HasIndex("Status");
            }

            entity.Property("CreationDate")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("(GETDATE())")
                .HasComment("Creation Date");

            entity.Property("IdCreationUser")
                .HasColumnName("IdCreationUser")
                .IsRequired(configBaseMap.CreationUserIsRequired);

            entity.Property("LastModificationDate")
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("(GETDATE())")
                .IsRequired(false);

            entity.Property("IdLastModificationUser")
                .HasColumnName("IdLastModificationUser")
                .IsRequired(false);

            entity.HasOne("CreationUser")
                .WithMany()
                .HasForeignKey("IdCreationUser")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"FK_{tableName}_Creation_User");

            entity.HasOne("LastModificationUser")
                .WithMany()
                .HasForeignKey("IdLastModificationUser")
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
