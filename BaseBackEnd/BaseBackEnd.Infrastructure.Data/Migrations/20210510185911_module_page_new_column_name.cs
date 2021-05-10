using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class module_page_new_column_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "IdModulePage",
                table: "ModulePageFunctionality",
                newName: "IdModule");

            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("565356f7-4192-4ad9-93b2-7f59267eab30"), "approve", "Change status to Approved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Approve", 1 },
                    { new Guid("1a775433-5ebf-45b7-9c88-8c76306cf974"), "disapprove", "Change status to Disapproved", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Disapprove", 1 },
                    { new Guid("41858062-f26d-4e4c-a043-c5f79088315a"), "activate", "Change status to Active", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Activate", 1 },
                    { new Guid("d0f1d0b4-29a2-4947-b659-5277392fe11d"), "inactivate", "Change status to Inactive", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Inactivate", 1 },
                    { new Guid("3b0ff8ed-552e-4382-9c84-8e25a5c23477"), "confirm", "Change status to Confirmed", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Confirm", 1 },
                    { new Guid("94c59cb1-90f4-42d9-9ddb-4da6f68b9150"), "cancel", "Change status to Canceled", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Cancel", 1 },
                    { new Guid("db12ca96-f66e-4b87-afb3-c1450136fccb"), "search", "Permits search", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Search", 1 },
                    { new Guid("0d2efc21-b550-4300-9f4b-a5f711025ead"), "export", "Permits export", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Export", 1 },
                    { new Guid("bf3deaa1-daa0-481a-8bfc-038b5cdb85cb"), "add", "Permits add", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Add", 1 },
                    { new Guid("f934ea9d-d333-433c-9697-b1ac08017ca6"), "update", "Permits update", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Update", 1 },
                    { new Guid("2ec55a70-9a2c-4910-9848-903d19d33be9"), "remove", "Permits remove", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Remove", 1 },
                    { new Guid("314b1eb3-c8db-4258-b9a2-8016d540a16e"), "consult", "Permits consults, but not updates", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Consult", 1 }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { new Guid("a8005864-8188-47cb-a256-f88ac42be388"), "security", "Security module", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Security", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("0d2efc21-b550-4300-9f4b-a5f711025ead"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("1a775433-5ebf-45b7-9c88-8c76306cf974"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("2ec55a70-9a2c-4910-9848-903d19d33be9"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("314b1eb3-c8db-4258-b9a2-8016d540a16e"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("3b0ff8ed-552e-4382-9c84-8e25a5c23477"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("41858062-f26d-4e4c-a043-c5f79088315a"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("565356f7-4192-4ad9-93b2-7f59267eab30"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("94c59cb1-90f4-42d9-9ddb-4da6f68b9150"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("bf3deaa1-daa0-481a-8bfc-038b5cdb85cb"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("d0f1d0b4-29a2-4947-b659-5277392fe11d"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("db12ca96-f66e-4b87-afb3-c1450136fccb"));

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: new Guid("f934ea9d-d333-433c-9697-b1ac08017ca6"));

            migrationBuilder.DeleteData(
                table: "Module",
                keyColumn: "Id",
                keyValue: new Guid("a8005864-8188-47cb-a256-f88ac42be388"));

            migrationBuilder.RenameColumn(
                name: "IdModule",
                table: "ModulePageFunctionality",
                newName: "IdModulePage");

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
        }
    }
}
