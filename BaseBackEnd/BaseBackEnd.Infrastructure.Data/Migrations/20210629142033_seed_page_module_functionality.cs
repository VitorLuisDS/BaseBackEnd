using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class seed_page_module_functionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Page",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { 1, "pages", "Pages page", 1, null, null, "Pages", 1 });

            migrationBuilder.InsertData(
                table: "ModulePage",
                columns: new[] { "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 9, 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 10, 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 11, 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 9, 1, 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 10, 1, 1, 1, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[] { 11, 1, 1, 1, 1, null, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProfileModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile" },
                keyValues: new object[] { 9, 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProfileModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile" },
                keyValues: new object[] { 10, 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProfileModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile" },
                keyValues: new object[] { 11, 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage" },
                keyValues: new object[] { 9, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage" },
                keyValues: new object[] { 10, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage" },
                keyValues: new object[] { 11, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModulePage",
                keyColumns: new[] { "IdModule", "IdPage" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
