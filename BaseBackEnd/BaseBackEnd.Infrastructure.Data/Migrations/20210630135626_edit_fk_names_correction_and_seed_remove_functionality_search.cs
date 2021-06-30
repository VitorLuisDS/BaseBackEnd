using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class edit_fk_names_correction_and_seed_remove_functionality_search : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModulePage__Module",
                table: "ModulePage");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulePage__Page",
                table: "ModulePage");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulePageFunctionality__Functionality",
                table: "ModulePageFunctionality");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulePageFunctionality__Module_Page",
                table: "ModulePageFunctionality");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModulePageFunctionality__ModulePageFunctionality",
                table: "ProfileModulePageFunctionality");

            migrationBuilder.DropForeignKey(
                name: "FK_Session__User",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionBlackList__Session",
                table: "SessionBlackList");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile__Profile",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile__User",
                table: "UserProfile");

            migrationBuilder.DeleteData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameIndex(
                name: "UN_Profile__Name",
                table: "Profile",
                newName: "UN_Profile_Name");

            migrationBuilder.UpdateData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Permits consult");

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePage_Module",
                table: "ModulePage",
                column: "IdModule",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePage_Page",
                table: "ModulePage",
                column: "IdPage",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePageFunctionality_Functionality",
                table: "ModulePageFunctionality",
                column: "IdFunctionality",
                principalTable: "Functionality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePageFunctionality_Module_Page",
                table: "ModulePageFunctionality",
                columns: new[] { "IdModule", "IdPage" },
                principalTable: "ModulePage",
                principalColumns: new[] { "IdModule", "IdPage" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModulePageFunctionality_ModulePageFunctionality",
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdModule", "IdPage", "IdFunctionality" },
                principalTable: "ModulePageFunctionality",
                principalColumns: new[] { "IdModule", "IdPage", "IdFunctionality" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_User",
                table: "Session",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionBlackList_Session",
                table: "SessionBlackList",
                column: "IdSession",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Profile",
                table: "UserProfile",
                column: "IdProfile",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_User",
                table: "UserProfile",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModulePage_Module",
                table: "ModulePage");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulePage_Page",
                table: "ModulePage");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulePageFunctionality_Functionality",
                table: "ModulePageFunctionality");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulePageFunctionality_Module_Page",
                table: "ModulePageFunctionality");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModulePageFunctionality_ModulePageFunctionality",
                table: "ProfileModulePageFunctionality");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_User",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionBlackList_Session",
                table: "SessionBlackList");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Profile",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_User",
                table: "UserProfile");

            migrationBuilder.RenameIndex(
                name: "UN_Profile_Name",
                table: "Profile",
                newName: "UN_Profile__Name");

            migrationBuilder.UpdateData(
                table: "Functionality",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Permits consults, but not updates");

            migrationBuilder.InsertData(
                table: "Functionality",
                columns: new[] { "Id", "Code", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { 7, "search", "Permits search", 1, null, null, "Search", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePage__Module",
                table: "ModulePage",
                column: "IdModule",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePage__Page",
                table: "ModulePage",
                column: "IdPage",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePageFunctionality__Functionality",
                table: "ModulePageFunctionality",
                column: "IdFunctionality",
                principalTable: "Functionality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulePageFunctionality__Module_Page",
                table: "ModulePageFunctionality",
                columns: new[] { "IdModule", "IdPage" },
                principalTable: "ModulePage",
                principalColumns: new[] { "IdModule", "IdPage" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModulePageFunctionality__ModulePageFunctionality",
                table: "ProfileModulePageFunctionality",
                columns: new[] { "IdModule", "IdPage", "IdFunctionality" },
                principalTable: "ModulePageFunctionality",
                principalColumns: new[] { "IdModule", "IdPage", "IdFunctionality" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Session__User",
                table: "Session",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionBlackList__Session",
                table: "SessionBlackList",
                column: "IdSession",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile__Profile",
                table: "UserProfile",
                column: "IdProfile",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile__User",
                table: "UserProfile",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
