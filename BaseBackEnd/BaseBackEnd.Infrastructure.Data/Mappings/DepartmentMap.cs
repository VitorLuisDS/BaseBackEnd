using BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            string tableName = nameof(Department);

            entity.ToTable(tableName);

            entity.HasKey(e => e.Id)
                .IsClustered();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasIndex(e => e.Name, $"UN_{tableName}_Name")
                .IsUnique();

            BaseMap.Configure(entity, tableName);
        }
    }
}
