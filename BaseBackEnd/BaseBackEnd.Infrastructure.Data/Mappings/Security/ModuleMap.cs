using BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Security
{
    public class ModuleMap : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> entity)
        {
            string tableName = nameof(Module);

            entity.ToTable(tableName);

            entity.HasKey(e => e.Id)
                .IsClustered();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasIndex(e => e.Name, $"UN_{tableName}_Name")
                .IsUnique();

            entity.HasIndex(e => e.Code, $"UN_{tableName}_Code")
                .IsUnique();

            BaseMap.Configure(entity, tableName);
        }
    }
}
