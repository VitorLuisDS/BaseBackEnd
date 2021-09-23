using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Migrations
{
    public partial class edit_session_blacklist_map : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_$Session__SessionBlackList",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionBlackList",
                table: "SessionBlackList");

            migrationBuilder.DropIndex(
                name: "IX_Session_IdSessionBlackList",
                table: "Session");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SessionBlackList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NEWID())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionBlackList",
                table: "SessionBlackList",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionBlackList_IdSession",
                table: "SessionBlackList",
                column: "IdSession",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_$SessionBlackList__Session",
                table: "SessionBlackList",
                column: "IdSession",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_$SessionBlackList__Session",
                table: "SessionBlackList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionBlackList",
                table: "SessionBlackList");

            migrationBuilder.DropIndex(
                name: "IX_SessionBlackList_IdSession",
                table: "SessionBlackList");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SessionBlackList",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(NEWID())");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionBlackList",
                table: "SessionBlackList",
                column: "Id");

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
    }
}
