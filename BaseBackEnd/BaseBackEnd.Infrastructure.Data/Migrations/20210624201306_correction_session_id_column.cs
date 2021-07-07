using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Migrations
{
    public partial class correction_session_id_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdNew",
                table: "Session",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Session",
                newName: "IdNew");
        }
    }
}
