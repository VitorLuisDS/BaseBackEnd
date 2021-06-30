using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class seed_page_module_functionality_consult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 12, 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 12, 1, 1, 1, 1, null, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProfileModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile" },
                keyValues: new object[] { 12, 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage" },
                keyValues: new object[] { 12, 1, 1 });
        }
    }
}
