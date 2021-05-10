using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class new_page_module_functionality_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("049a628a-841b-4013-9611-09074959482c"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("0b176f3c-e5b4-436c-aa9f-cb158aba9282"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("0ef80e82-288e-458a-a448-4d946b395c08"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("304bbb3c-85cd-4532-b5d0-433b81855e6b"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("355aa026-4102-41f9-9f20-55872d963e77"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("41ea73a9-ab7e-4c2f-8a1a-636f0cdd502e"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("432d5074-9970-472b-9b64-41cf9caafb3e"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("5567edf0-a65c-463b-93a2-8de82b77c226"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("5d1d862e-f5ee-469b-8aef-33be0827c7da"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("79614573-9237-434e-bae4-a26c0fb67710"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("a6334d41-9ff5-4a03-8440-4f8c5170322b"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("fc438ed5-bb4e-4925-bd39-d920a4475e42"));

            migrationBuilder.DeleteData(
                table: "Module",
                keyColumn: "Id",
                keyValue: new Guid("0a7516bd-6320-4775-943f-ca4b2fce11b8"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Page",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Module",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Functionality",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("3a414c46-bfb6-4c49-934a-9ace5316dafa"), "approve", "Change status to Approved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Approve", 1 },
                    { new Guid("0c6f43c8-3645-413e-ad26-611400bd4a77"), "disapprove", "Change status to Disapproved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Disapprove", 1 },
                    { new Guid("164755fe-aeaa-43d7-85e3-afbccb32a626"), "activate", "Change status to Active", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Activate", 1 },
                    { new Guid("1b6b34a6-11a1-4ba5-8ea0-ea3fdddd982e"), "inactivate", "Change status to Inactive", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Inactivate", 1 },
                    { new Guid("fb36a7a3-d2bc-4b51-bef9-7b15a0fba5ae"), "confirm", "Change status to Confirmed", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Confirm", 1 },
                    { new Guid("6894f3b5-3e37-4b47-b17e-6c59ed99acb4"), "cancel", "Change status to Canceled", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Cancel", 1 },
                    { new Guid("07fc9067-bf06-4b12-be2a-8cfc0eecb244"), "search", "Permits search", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Search", 1 },
                    { new Guid("2ce22226-27ee-4b35-98f2-47176fde8936"), "export", "Permits export", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Export", 1 },
                    { new Guid("72e39127-60ee-464b-b863-51bcbd6404d5"), "add", "Permits add", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Add", 1 },
                    { new Guid("f9866655-06d8-4303-ac20-8b275c1f8436"), "update", "Permits update", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Update", 1 },
                    { new Guid("47f8b0d5-89f7-446c-8ace-f856f3152487"), "remove", "Permits remove", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Remove", 1 },
                    { new Guid("1a9412f6-e200-4ce3-ab37-9249a4edc60e"), "consult", "Permits consults, but not updates", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { new Guid("d4ef042b-200a-442d-96fd-53cc86de6564"), "security", "Security module", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Security", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Name",
                value: "Development");

            migrationBuilder.CreateIndex(
                name: "UN_Page_Code",
                table: "Page",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UN_Module_Code",
                table: "Module",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UN_Functionality_Code",
                table: "Functionality",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UN_Page_Code",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "UN_Module_Code",
                table: "Module");

            migrationBuilder.DropIndex(
                name: "UN_Functionality_Code",
                table: "Functionality");

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("07fc9067-bf06-4b12-be2a-8cfc0eecb244"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("0c6f43c8-3645-413e-ad26-611400bd4a77"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("164755fe-aeaa-43d7-85e3-afbccb32a626"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("1a9412f6-e200-4ce3-ab37-9249a4edc60e"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("1b6b34a6-11a1-4ba5-8ea0-ea3fdddd982e"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("2ce22226-27ee-4b35-98f2-47176fde8936"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("3a414c46-bfb6-4c49-934a-9ace5316dafa"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("47f8b0d5-89f7-446c-8ace-f856f3152487"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("6894f3b5-3e37-4b47-b17e-6c59ed99acb4"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("72e39127-60ee-464b-b863-51bcbd6404d5"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("f9866655-06d8-4303-ac20-8b275c1f8436"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("fb36a7a3-d2bc-4b51-bef9-7b15a0fba5ae"));

            migrationBuilder.DeleteData(
                table: "Module",
                keyColumn: "Id",
                keyValue: new Guid("d4ef042b-200a-442d-96fd-53cc86de6564"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Functionality");

            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("304bbb3c-85cd-4532-b5d0-433b81855e6b"), "Change status to Approved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Aprove", 1 },
                    { new Guid("0b176f3c-e5b4-436c-aa9f-cb158aba9282"), "Change status to Disapproved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Disapprove", 1 },
                    { new Guid("41ea73a9-ab7e-4c2f-8a1a-636f0cdd502e"), "Change status to Active", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Activate", 1 },
                    { new Guid("a6334d41-9ff5-4a03-8440-4f8c5170322b"), "Change status to Inactive", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Inactivate", 1 },
                    { new Guid("049a628a-841b-4013-9611-09074959482c"), "Change status to Confirmed", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Confirm", 1 },
                    { new Guid("5567edf0-a65c-463b-93a2-8de82b77c226"), "Change status to Canceled", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Cancel", 1 },
                    { new Guid("355aa026-4102-41f9-9f20-55872d963e77"), "Permits search", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Search", 1 },
                    { new Guid("0ef80e82-288e-458a-a448-4d946b395c08"), "Permits export", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Export", 1 },
                    { new Guid("79614573-9237-434e-bae4-a26c0fb67710"), "Permits add", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Add", 1 },
                    { new Guid("432d5074-9970-472b-9b64-41cf9caafb3e"), "Permits update", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Update", 1 },
                    { new Guid("fc438ed5-bb4e-4925-bd39-d920a4475e42"), "Permits remove", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Remove", 1 },
                    { new Guid("5d1d862e-f5ee-469b-8aef-33be0827c7da"), "Permits consults, but not updates", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { new Guid("0a7516bd-6320-4775-943f-ca4b2fce11b8"), "Security module", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Security", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Name",
                value: null);
        }
    }
}
