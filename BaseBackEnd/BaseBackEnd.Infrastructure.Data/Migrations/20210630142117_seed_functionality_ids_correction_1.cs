using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class seed_functionality_ids_correction_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 8);

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
                table: "ProfileModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile" },
                keyValues: new object[] { 12, 1, 1, 1 });

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
                table: "ModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage" },
                keyValues: new object[] { 12, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { 7, "export", "Permits export", 1, null, null, "Export", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { 8, "export", "Permits export", 1, null, null, "Export", 1 },
                    { 9, "add", "Permits add", 1, null, null, "Add", 1 },
                    { 10, "update", "Permits update", 1, null, null, "Update", 1 },
                    { 11, "remove", "Permits remove", 1, null, null, "Remove", 1 },
                    { 12, "consult", "Permits consult", 1, null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "ModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[,]
                {
                    { 9, 1, 1, 1, null, null, 1 },
                    { 10, 1, 1, 1, null, null, 1 },
                    { 11, 1, 1, 1, null, null, 1 },
                    { 12, 1, 1, 1, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[,]
                {
                    { 9, 1, 1, 1, 1, null, null, 1 },
                    { 10, 1, 1, 1, 1, null, null, 1 },
                    { 11, 1, 1, 1, 1, null, null, 1 },
                    { 12, 1, 1, 1, 1, null, null, 1 }
                });
        }
    }
}
