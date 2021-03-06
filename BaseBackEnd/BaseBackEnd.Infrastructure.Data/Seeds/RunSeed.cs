using BaseBackEnd.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaseBackEnd.Infrastructure.Data.Seeds
{
    public static class RunSeed
    {
        public static Guid IdUserDev = new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid IdProfileDev = new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid IdDepartmentDev = new Guid("00000000-0000-0000-0000-000000000001");
        public static string LoginDev = "dev";
        public static string PasswordDev = "dev";
        public static void SeedAsync(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = IdUserDev,
                    Login = LoginDev,
                    Password = "123",
                    IdProfile = IdProfileDev,
                    IdDepartment = IdDepartmentDev,
                    LastModificationDate = null,
                    IdCreationUser = IdUserDev
                });

            modelBuilder.Entity<Functionality>()
                .HasData(new Functionality[]
                {
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Aprove",
                        Description = "Change status to Approved",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Disapprove",
                        Description = "Change status to Disapproved",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Activate",
                        Description = "Change status to Active",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Inactivate",
                        Description = "Change status to Inactive",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Confirm",
                        Description = "Change status to Confirmed",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cancel",
                        Description = "Change status to Canceled",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Search",
                        Description = "Permits search",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Export",
                        Description = "Permits export",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Add",
                        Description = "Permits add",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Update",
                        Description = "Permits update",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Remove",
                        Description = "Permits remove",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = Guid.NewGuid(),
                        Name = "Consult",
                        Description = "Permits consults, but not updates",
                        IdCreationUser = IdUserDev
                    }
                });

            modelBuilder.Entity<Module>()
                .HasData(new Module
                {
                    Id = Guid.NewGuid(),
                    Name = "Security",
                    Description = "Security module",
                    IdCreationUser = IdUserDev
                });
        }
    }
}
