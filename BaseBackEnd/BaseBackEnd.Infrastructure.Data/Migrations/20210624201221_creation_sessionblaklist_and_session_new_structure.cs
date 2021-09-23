using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Migrations
{
    public partial class creation_sessionblaklist_and_session_new_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Session");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNew",
                table: "Session",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NEWID())");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSessionBlackList",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "IdNew")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateTable(
                name: "SessionBlackList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSession = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionBlackList", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "202cb962ac59075b964b07152d234b70");

            migrationBuilder.CreateIndex(
                name: "IX_Session_IdSessionBlackList",
                table: "Session",
                column: "IdSessionBlackList",
                unique: true,
                filter: "[IdSessionBlackList] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_$Session__SessionBlackList",
                table: "Session",
                column: "IdSessionBlackList",
                principalTable: "SessionBlackList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_$Session__SessionBlackList",
                table: "Session");

            migrationBuilder.DropTable(
                name: "SessionBlackList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_IdSessionBlackList",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "IdNew",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "IdSessionBlackList",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123");
        }
    }
}
