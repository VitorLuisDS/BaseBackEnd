using BaseBackEnd.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaseBackEnd.Infrastructure.Data.Seeds
{
    public static class RunSeed
    {
        public static int IdUserDev = 1;
        public static int IdProfileDev = 1;
        public static int IdDepartmentDev = 1;
        public static int IdSecurityModule = 1;
        public static int IdPagePages = 1;
        public static int IdAddFunctionality = 9;
        public static int IdUpdateFunctionality = 10;
        public static int IdRemoveFunctionality = 11;
        public static string LoginDev = "dev";
        public static string PasswordDev = "dev";
        public static void SeedAsync(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = IdUserDev,
                    Name = "Development",
                    Login = LoginDev,
                    Password = "202cb962ac59075b964b07152d234b70",//123
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
                        Id = 1,
                        Code="approve",
                        Name = "Approve",
                        Description = "Change status to Approved",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 2,
                        Code = "disapprove",
                        Name = "Disapprove",
                        Description = "Change status to Disapproved",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 3,
                        Code = "activate",
                        Name = "Activate",
                        Description = "Change status to Active",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 4,
                        Code = "inactivate",
                        Name = "Inactivate",
                        Description = "Change status to Inactive",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 5,
                        Code = "confirm",
                        Name = "Confirm",
                        Description = "Change status to Confirmed",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 6,
                        Code = "cancel",
                        Name = "Cancel",
                        Description = "Change status to Canceled",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 7,
                        Code = "search",
                        Name = "Search",
                        Description = "Permits search",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 8,
                        Code = "export",
                        Name = "Export",
                        Description = "Permits export",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdAddFunctionality,
                        Code = "add",
                        Name = "Add",
                        Description = "Permits add",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdUpdateFunctionality,
                        Code = "update",
                        Name = "Update",
                        Description = "Permits update",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdRemoveFunctionality,
                        Code = "remove",
                        Name = "Remove",
                        Description = "Permits remove",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 12,
                        Code = "consult",
                        Name = "Consult",
                        Description = "Permits consults, but not updates",
                        IdCreationUser = IdUserDev
                    }
                });

            modelBuilder.Entity<Module>()
                .HasData(new Module
                {
                    Id = IdSecurityModule,
                    Code = "security",
                    Name = "Security",
                    Description = "Security module",
                    IdCreationUser = IdUserDev
                });

            modelBuilder.Entity<Page>()
                .HasData(new Page
                {
                    Id = IdPagePages,
                    Code = "pages",
                    Name = "Pages",
                    Description = "Pages page",
                    IdCreationUser = IdUserDev,
                });

            modelBuilder.Entity<ModulePage>()
                .HasData(new ModulePage
                {
                    IdModule = IdSecurityModule,
                    IdPage = IdPagePages,
                    IdCreationUser = IdUserDev
                });

            modelBuilder.Entity<ModulePageFunctionality>()
                .HasData(new ModulePageFunctionality[] 
                {
                    new ModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdAddFunctionality,
                        IdCreationUser = IdUserDev
                    },
                    new ModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdUpdateFunctionality,
                        IdCreationUser = IdUserDev
                    },
                    new ModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdRemoveFunctionality,
                        IdCreationUser = IdUserDev
                    },
                });

            modelBuilder.Entity<ProfileModulePageFunctionality>()
                .HasData(new ProfileModulePageFunctionality[] 
                {
                    new ProfileModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdAddFunctionality,
                        IdProfile=IdProfileDev,
                        IdCreationUser = IdUserDev
                    },
                    new ProfileModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdUpdateFunctionality,
                        IdProfile=IdProfileDev,
                        IdCreationUser = IdUserDev
                    },
                    new ProfileModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdRemoveFunctionality,
                        IdProfile=IdProfileDev,
                        IdCreationUser = IdUserDev
                    },
                });
        }
    }
}
