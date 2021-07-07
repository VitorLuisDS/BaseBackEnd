using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Migrations
{
    public partial class edit_fk_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_$Session__User",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_$SessionBlackList__Session",
                table: "SessionBlackList");

            migrationBuilder.AddForeignKey(
                name: "FK_Session__User",
                table: "Session",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionBlackList__Session",
                table: "SessionBlackList",
                column: "IdSession",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session__User",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionBlackList__Session",
                table: "SessionBlackList");

            migrationBuilder.AddForeignKey(
                name: "FK_$Session__User",
                table: "Session",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_$SessionBlackList__Session",
                table: "SessionBlackList",
                column: "IdSession",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
