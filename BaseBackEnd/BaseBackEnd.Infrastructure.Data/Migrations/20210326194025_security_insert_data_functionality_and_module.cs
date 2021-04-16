using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class security_insert_data_functionality_and_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("07928efb-aa9f-43a3-bafa-63064fd9055d"), "Change status to Approved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Aprove", 1 },
                    { new Guid("ca768f52-ccd1-4fd8-973d-727850d2daba"), "Change status to Disapproved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Disapprove", 1 },
                    { new Guid("b0f20abf-6851-491e-9137-8ff5043ea178"), "Change status to Active", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Activate", 1 },
                    { new Guid("96641af5-e11e-48b1-95b1-e69ee18efc4d"), "Change status to Inactive", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Inactivate", 1 },
                    { new Guid("0e391308-71ff-4693-9373-4261be70fd13"), "Change status to Confirmed", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Confirm", 1 },
                    { new Guid("76158192-c19b-40b8-9321-6f4103fd9df1"), "Change status to Canceled", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Cancel", 1 },
                    { new Guid("74c167a4-9795-40be-9cbd-147a674a8084"), "Permits search", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Search", 1 },
                    { new Guid("32106069-dd0d-43bb-a06a-f1619070147c"), "Permits export", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Export", 1 },
                    { new Guid("9288ce53-9b23-44f5-97fd-1c9826bcff0c"), "Permits add", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Add", 1 },
                    { new Guid("7607b464-dc1d-4d6a-8c68-9896e9219d0e"), "Permits update", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Update", 1 },
                    { new Guid("7ac17f35-27e8-4a06-ad5d-fe794b3505ed"), "Permits remove", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Remove", 1 },
                    { new Guid("b864ae65-dde8-41ca-9a37-9eb216d50108"), "Permits consults, but not updates", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { new Guid("0774f5e2-390d-456e-a56e-f9b434d52d07"), "Security module", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Security", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("07928efb-aa9f-43a3-bafa-63064fd9055d"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("0e391308-71ff-4693-9373-4261be70fd13"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("32106069-dd0d-43bb-a06a-f1619070147c"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("74c167a4-9795-40be-9cbd-147a674a8084"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("7607b464-dc1d-4d6a-8c68-9896e9219d0e"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("76158192-c19b-40b8-9321-6f4103fd9df1"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("7ac17f35-27e8-4a06-ad5d-fe794b3505ed"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("9288ce53-9b23-44f5-97fd-1c9826bcff0c"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("96641af5-e11e-48b1-95b1-e69ee18efc4d"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("b0f20abf-6851-491e-9137-8ff5043ea178"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("b864ae65-dde8-41ca-9a37-9eb216d50108"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("ca768f52-ccd1-4fd8-973d-727850d2daba"));

            migrationBuilder.DeleteData(
                table: "Module",
                keyColumn: "Id",
                keyValue: new Guid("0774f5e2-390d-456e-a56e-f9b434d52d07"));
        }
    }
}
