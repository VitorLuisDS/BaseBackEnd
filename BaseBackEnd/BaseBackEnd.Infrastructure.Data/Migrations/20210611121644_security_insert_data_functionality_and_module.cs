using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Migrations
{
    public partial class security_insert_data_functionality_and_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "approve", "Change status to Approved", 1, null, null, "Approve", 1 },
                    { 2, "disapprove", "Change status to Disapproved", 1, null, null, "Disapprove", 1 },
                    { 3, "activate", "Change status to Active", 1, null, null, "Activate", 1 },
                    { 4, "inactivate", "Change status to Inactive", 1, null, null, "Inactivate", 1 },
                    { 5, "confirm", "Change status to Confirmed", 1, null, null, "Confirm", 1 },
                    { 6, "cancel", "Change status to Canceled", 1, null, null, "Cancel", 1 },
                    { 7, "search", "Permits search", 1, null, null, "Search", 1 },
                    { 8, "export", "Permits export", 1, null, null, "Export", 1 },
                    { 9, "add", "Permits add", 1, null, null, "Add", 1 },
                    { 10, "update", "Permits update", 1, null, null, "Update", 1 },
                    { 11, "remove", "Permits remove", 1, null, null, "Remove", 1 },
                    { 12, "consult", "Permits consults, but not updates", 1, null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { 1, "security", "Security module", 1, null, null, "Security", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 7);

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

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
