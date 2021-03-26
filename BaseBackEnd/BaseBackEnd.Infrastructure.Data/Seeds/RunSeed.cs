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
            //modelBuilder.Entity<User>()
            //    .HasData(new User
            //    {
            //        Id = IdUserDev,
            //        Login = LoginDev,
            //        Password = "123",
            //        IdProfile = IdProfileDev,
            //        IdDepartment = IdDepartmentDev,
            //        LastModificationDate = null,
            //        IdCreationUser = IdUserDev
            //    });

            //modelBuilder.Entity<Department>()
            //    .HasData(new Department
            //    {
            //        Id = IdDepartmentDev,
            //        Name = "Development",
            //        Description = "Development department",
            //        LastModificationDate = null,
            //        IdCreationUser = IdUserDev
            //    });

            //modelBuilder.Entity<Profile>()
            //    .HasData(new Profile
            //    {
            //        Id = IdDepartmentDev,
            //        Name = "Development",
            //        Description = "Development profile",
            //        LastModificationDate = null,
            //        IdCreationUser = IdUserDev
            //    });
        }
    }
}
