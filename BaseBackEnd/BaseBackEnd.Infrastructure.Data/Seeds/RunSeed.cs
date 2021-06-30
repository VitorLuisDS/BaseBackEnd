using BaseBackEnd.Domain.Constants.Security;
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
        public static int IdConsultFunctionality = 12;
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
                        Code = FunctionalityCodes.Approve,
                        Name = "Approve",
                        Description = "Change status to Approved",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 2,
                        Code = FunctionalityCodes.Disapprove,
                        Name = "Disapprove",
                        Description = "Change status to Disapproved",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 3,
                        Code = FunctionalityCodes.Activate,
                        Name = "Activate",
                        Description = "Change status to Active",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 4,
                        Code = FunctionalityCodes.Inactivate,
                        Name = "Inactivate",
                        Description = "Change status to Inactive",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 5,
                        Code = FunctionalityCodes.Confirm,
                        Name = "Confirm",
                        Description = "Change status to Confirmed",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 6,
                        Code = FunctionalityCodes.Cancel,
                        Name = "Cancel",
                        Description = "Change status to Canceled",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = 8,
                        Code = FunctionalityCodes.Export,
                        Name = "Export",
                        Description = "Permits export",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdAddFunctionality,
                        Code = FunctionalityCodes.Add,
                        Name = "Add",
                        Description = "Permits add",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdUpdateFunctionality,
                        Code = FunctionalityCodes.Update,
                        Name = "Update",
                        Description = "Permits update",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdRemoveFunctionality,
                        Code = FunctionalityCodes.Remove,
                        Name = "Remove",
                        Description = "Permits remove",
                        IdCreationUser = IdUserDev
                    },
                    new Functionality
                    {
                        Id = IdConsultFunctionality,
                        Code = FunctionalityCodes.Consult,
                        Name = "Consult",
                        Description = "Permits consult",
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
                    new ModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdConsultFunctionality,
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
                    new ProfileModulePageFunctionality
                    {
                        IdModule = IdSecurityModule,
                        IdPage = IdPagePages,
                        IdFunctionality = IdConsultFunctionality,
                        IdProfile=IdProfileDev,
                        IdCreationUser = IdUserDev
                    },
                });

            modelBuilder.Entity<UserProfile>()
                .HasData(new UserProfile[]
                {
                    new UserProfile
                    {
                        IdProfile = IdProfileDev,
                        IdUser = IdUserDev,
                        IdCreationUser = IdUserDev
                    },
                });
        }
    }
}
