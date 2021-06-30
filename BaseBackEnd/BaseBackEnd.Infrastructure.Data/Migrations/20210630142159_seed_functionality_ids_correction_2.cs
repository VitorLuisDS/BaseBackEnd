using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class seed_functionality_ids_correction_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { 8, "add", "Permits add", 1, null, null, "Add", 1 },
                    { 9, "update", "Permits update", 1, null, null, "Update", 1 },
                    { 10, "remove", "Permits remove", 1, null, null, "Remove", 1 },
                    { 11, "consult", "Permits consult", 1, null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "ModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[,]
                {
                    { 8, 1, 1, 1, null, null, 1 },
                    { 9, 1, 1, 1, null, null, 1 },
                    { 10, 1, 1, 1, null, null, 1 },
                    { 11, 1, 1, 1, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Status" },
                values: new object[,]
                {
                    { 8, 1, 1, 1, 1, null, null, 1 },
                    { 9, 1, 1, 1, 1, null, null, 1 },
                    { 10, 1, 1, 1, 1, null, null, 1 },
                    { 11, 1, 1, 1, 1, null, null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProfileModulePageFunctionality",
                keyColumns: new[] { "IdFunctionality", "IdModule", "IdPage", "IdProfile" },
                keyValues: new object[] { 8, 1, 1, 1 });

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
                keyValues: new object[] { 8, 1, 1 });

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
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 8);

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
        }
    }
}
