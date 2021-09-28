using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Migrations
{
    public partial class create_user_profile_and_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Profile",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdProfile",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdProfile",
                table: "User");

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdProfile = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GETDATE())"),
                    IdCreationUser = table.Column<int>(type: "int", nullable: false),
                    IdLastModificationUser = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(1)))", comment: "Status of UserProfile. Inactive = 0, Active=1, Blocked = 2, Deleted = 3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => new { x.IdUser, x.IdProfile })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_UserProfile__Profile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile__User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Creation_User",
                        column: x => x.IdCreationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Last_Modification_User",
                        column: x => x.IdLastModificationUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "IdProfile", "IdUser", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 1, 1, 1, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_IdCreationUser",
                table: "UserProfile",
                column: "IdCreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_IdLastModificationUser",
                table: "UserProfile",
                column: "IdLastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_IdProfile",
                table: "UserProfile",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_Status",
                table: "UserProfile",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.AddColumn<int>(
                name: "IdProfile",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdProfile",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdProfile",
                table: "User",
                column: "IdProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profile",
                table: "User",
                column: "IdProfile",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
