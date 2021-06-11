﻿// <auto-generated />
using System;
using BaseBackEnd.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ProjectBaseContext))]
    [Migration("20210611121531_security_insert_data")]
    partial class security_insert_data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of Department. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.HasIndex(new[] { "Name" }, "UN_Department_Name")
                        .IsUnique();

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Functionality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of Functionality. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.HasIndex(new[] { "Code" }, "UN_Functionality_Code")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "UN_Functionality_Name")
                        .IsUnique();

                    b.ToTable("Functionality");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of Module. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.HasIndex(new[] { "Code" }, "UN_Module_Code")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "UN_Module_Name")
                        .IsUnique();

                    b.ToTable("Module");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ModulePage", b =>
                {
                    b.Property<int>("IdModule")
                        .HasColumnType("int");

                    b.Property<int>("IdPage")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of ModulePage. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("IdModule", "IdPage")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("IdPage");

                    b.HasIndex("Status");

                    b.ToTable("ModulePage");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ModulePageFunctionality", b =>
                {
                    b.Property<int>("IdModule")
                        .HasColumnType("int");

                    b.Property<int>("IdPage")
                        .HasColumnType("int");

                    b.Property<int>("IdFunctionality")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of ModulePageFunctionality. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("IdModule", "IdPage", "IdFunctionality")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdFunctionality");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.ToTable("ModulePageFunctionality");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of Page. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.HasIndex(new[] { "Code" }, "UN_Page_Code")
                        .IsUnique();

                    b.ToTable("Page");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of Profile. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("DepartmentId");

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.HasIndex(new[] { "Name" }, "UN_Profile__Name")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ProfileModulePageFunctionality", b =>
                {
                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<int>("IdModule")
                        .HasColumnType("int");

                    b.Property<int>("IdPage")
                        .HasColumnType("int");

                    b.Property<int>("IdFunctionality")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of ProfileModulePageFunctionality. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("IdProfile", "IdModule", "IdPage", "IdFunctionality")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("Status");

                    b.HasIndex("IdModule", "IdPage", "IdFunctionality");

                    b.ToTable("ProfileModulePageFunctionality");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<bool?>("StayConnected")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("IdUser");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<int>("IdCreationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdCreationUser");

                    b.Property<int>("IdDepartment")
                        .HasColumnType("int");

                    b.Property<int?>("IdLastModificationUser")
                        .HasColumnType("int")
                        .HasColumnName("IdLastModificationUser");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModificationDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Login")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))")
                        .HasComment("Status of User. Inactive = 0, Active=1, Blocked = 2, Deleted = 3");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("IdCreationUser");

                    b.HasIndex("IdDepartment");

                    b.HasIndex("IdLastModificationUser");

                    b.HasIndex("IdProfile");

                    b.HasIndex("Status");

                    b.HasIndex(new[] { "Login" }, "UN_User_Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCreationUser = 1,
                            IdDepartment = 1,
                            IdProfile = 1,
                            Login = "dev",
                            Name = "Development",
                            Password = "123",
                            Status = 1
                        });
                });

            modelBuilder.Entity("BaseBackEnd.Infrastructure.Data.Context.DatabaseFunctions.DbFuncs", b =>
                {
                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NewId")
                        .HasColumnType("uniqueidentifier");

                    b
                        .HasAnnotation("Relational:SqlQuery", "SELECT GETDATE() AS DateTime, NEWID() as NewId");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Department", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_Department_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_Department_Last_Modification_User");

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Functionality", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_Functionality_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_Functionality_Last_Modification_User");

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Module", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_Module_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_Module_Last_Modification_User");

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ModulePage", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_ModulePage_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_ModulePage_Last_Modification_User");

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Module", "Module")
                        .WithMany("ModulePages")
                        .HasForeignKey("IdModule")
                        .HasConstraintName("FK_ModulePage__Module")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Page", "Page")
                        .WithMany("ModulePages")
                        .HasForeignKey("IdPage")
                        .HasConstraintName("FK_ModulePage__Page")
                        .IsRequired();

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");

                    b.Navigation("Module");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ModulePageFunctionality", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_ModulePageFunctionality_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Functionality", "Functionality")
                        .WithMany("ModulePageFunctionalities")
                        .HasForeignKey("IdFunctionality")
                        .HasConstraintName("FK_ModulePageFunctionality__Functionality")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_ModulePageFunctionality_Last_Modification_User");

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.ModulePage", "ModulePage")
                        .WithMany("ModulePageFunctionalities")
                        .HasForeignKey("IdModule", "IdPage")
                        .HasConstraintName("FK_ModulePageFunctionality__Module_Page")
                        .IsRequired();

                    b.Navigation("CreationUser");

                    b.Navigation("Functionality");

                    b.Navigation("LastModificationUser");

                    b.Navigation("ModulePage");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Page", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_Page_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_Page_Last_Modification_User");

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Profile", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Department", null)
                        .WithMany("Profiles")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_Profile_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_Profile_Last_Modification_User");

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ProfileModulePageFunctionality", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_ProfileModulePageFunctionality_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_ProfileModulePageFunctionality_Last_Modification_User");

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Profile", "Profile")
                        .WithMany("ProfileModulePageFunctionalities")
                        .HasForeignKey("IdProfile")
                        .HasConstraintName("FK_ProfileModulePageFunctionality_Profile")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.ModulePageFunctionality", "ModulePageFunctionality")
                        .WithMany("ProfileModulePageFunctionalities")
                        .HasForeignKey("IdModule", "IdPage", "IdFunctionality")
                        .HasConstraintName("FK_ProfileModulePageFunctionality__ModulePageFunctionality")
                        .IsRequired();

                    b.Navigation("CreationUser");

                    b.Navigation("LastModificationUser");

                    b.Navigation("ModulePageFunctionality");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Session", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_$Session__User")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.User", b =>
                {
                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "CreationUser")
                        .WithMany()
                        .HasForeignKey("IdCreationUser")
                        .HasConstraintName("FK_User_Creation_User")
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("IdDepartment")
                        .HasConstraintName("FK_User_Department")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.User", "LastModificationUser")
                        .WithMany()
                        .HasForeignKey("IdLastModificationUser")
                        .HasConstraintName("FK_User_Last_Modification_User");

                    b.HasOne("BaseBackEnd.Domain.Entities.Security.Profile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("IdProfile")
                        .HasConstraintName("FK_User_Profile")
                        .IsRequired();

                    b.Navigation("CreationUser");

                    b.Navigation("Department");

                    b.Navigation("LastModificationUser");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Department", b =>
                {
                    b.Navigation("Profiles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Functionality", b =>
                {
                    b.Navigation("ModulePageFunctionalities");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Module", b =>
                {
                    b.Navigation("ModulePages");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ModulePage", b =>
                {
                    b.Navigation("ModulePageFunctionalities");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.ModulePageFunctionality", b =>
                {
                    b.Navigation("ProfileModulePageFunctionalities");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Page", b =>
                {
                    b.Navigation("ModulePages");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.Profile", b =>
                {
                    b.Navigation("ProfileModulePageFunctionalities");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BaseBackEnd.Domain.Entities.Security.User", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
