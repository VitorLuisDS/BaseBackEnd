using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class create_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Name = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of Profile. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Login = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IdProfile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDepartment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of User. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Profile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of Department. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Department_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Functionality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of Functionality. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functionality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Functionality_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Functionality_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of Module. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Module_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of Page. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Page_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    KeepConected = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_$Session__User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModulePage",
                columns: table => new
                {
                    IdModule = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    IdPage = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of ModulePage. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulePage", x => new { x.IdModule, x.IdPage });
                    table.ForeignKey(
                        name: "FK_ModulePage__Module",
                        column: x => x.IdModule,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModulePage__Page",
                        column: x => x.IdPage,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModulePage_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModulePage_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModulePageFunctionality",
                columns: table => new
                {
                    IdModulePage = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    IdPage = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    IdFunctionality = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of ModulePageFunctionality. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulePageFunctionality", x => new { x.IdModulePage, x.IdPage, x.IdFunctionality });
                    table.ForeignKey(
                        name: "FK_ModulePageFunctionality__Functionality",
                        column: x => x.IdFunctionality,
                        principalTable: "Functionality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModulePageFunctionality__Module_Page",
                        columns: x => new { x.IdModulePage, x.IdPage },
                        principalTable: "ModulePage",
                        principalColumns: new[] { "IdModule", "IdPage" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModulePageFunctionality_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModulePageFunctionality_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileModulePageFunctionality",
                columns: table => new
                {
                    IdModule = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    IdPage = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    IdFunctionality = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 50, nullable: false),
                    IdProfile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())", comment: "Creation Date"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLastModificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of ProfileModulePageFunctionality. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileModulePageFunctionality", x => new { x.IdProfile, x.IdModule, x.IdPage, x.IdFunctionality });
                    table.ForeignKey(
                        name: "FK_ProfileModulePageFunctionality__ModulePageFunctionality",
                        columns: x => new { x.IdModule, x.IdPage, x.IdFunctionality },
                        principalTable: "ModulePageFunctionality",
                        principalColumns: new[] { "IdModulePage", "IdPage", "IdFunctionality" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileModulePageFunctionality_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileModulePageFunctionality_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileModulePageFunctionality_Profile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_IdCreationUser",
                table: "Department",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Department_IdLastModificationUser",
                table: "Department",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Status",
                table: "Department",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "UN_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Functionality_IdCreationUser",
                table: "Functionality",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Functionality_IdLastModificationUser",
                table: "Functionality",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Functionality_Status",
                table: "Functionality",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "UN_Functionality_Name",
                table: "Functionality",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Module_IdCreationUser",
                table: "Module",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Module_IdLastModificationUser",
                table: "Module",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Status",
                table: "Module",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "UN_Module_Name",
                table: "Module",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModulePage_IdCreationUser",
                table: "ModulePage",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePage_IdLastModificationUser",
                table: "ModulePage",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePage_IdPage",
                table: "ModulePage",
                column: "IdPage");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePage_Status",
                table: "ModulePage",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePageFunctionality_IdCreationUser",
                table: "ModulePageFunctionality",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePageFunctionality_IdFunctionality",
                table: "ModulePageFunctionality",
                column: "IdFunctionality");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePageFunctionality_IdLastModificationUser",
                table: "ModulePageFunctionality",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ModulePageFunctionality_Status",
                table: "ModulePageFunctionality",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Page_IdCreationUser",
                table: "Page",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Page_IdLastModificationUser",
                table: "Page",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Page_Status",
                table: "Page",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_DepartmentId",
                table: "Profile",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IdCreationUser",
                table: "Profile",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IdLastModificationUser",
                table: "Profile",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Status",
                table: "Profile",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "UN_Profile__Name",
                table: "Profile",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModulePageFunctionality_IdCreationUser",
                table: "ProfileModulePageFunctionality",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModulePageFunctionality_IdLastModificationUser",
                table: "ProfileModulePageFunctionality",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModulePageFunctionality_IdModule_IdPage_IdFunctionality",
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdModule", "IdPage", "IdFunctionality" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModulePageFunctionality_Status",
                table: "ProfileModulePageFunctionality",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Session_IdUser",
                table: "Session",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdCreationUser",
                table: "User",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdDepartment",
                table: "User",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdLastModificationUser",
                table: "User",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdProfile",
                table: "User",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_User_Status",
                table: "User",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "UN_User_Login",
                table: "User",
                column: "Login",
                unique: true,
                filter: "[Login] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Creation_User",
                table: "Profile",
                column: "IdCreationUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Last_Modification_User",
                table: "Profile",
                column: "IdLastModificationUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Department_DepartmentId",
                table: "Profile",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Department",
                table: "User",
                column: "IdDepartment",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Creation_User",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Last_Modification_User",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Creation_User",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Last_Modification_User",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "ProfileModulePageFunctionality");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "ModulePageFunctionality");

            migrationBuilder.DropTable(
                name: "Functionality");

            migrationBuilder.DropTable(
                name: "ModulePage");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
