using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BaseBackEnd.Infrastructure.Data.Migrations
{
    public partial class security_insert_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @sql NVARCHAR(MAX) = N'';

                                                ;WITH x AS 
                                                (
                                                  SELECT DISTINCT obj = 
                                                      QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' 
                                                    + QUOTENAME(OBJECT_NAME(parent_object_id)) 
                                                  FROM sys.foreign_keys
                                                )
                                                SELECT @sql += N'ALTER TABLE ' + obj + ' NOCHECK CONSTRAINT ALL;
                                                ' FROM x;

                                                EXEC sp_executesql @sql;");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "IdCreationUser", "IdDepartment", "IdLastModificationUser", "IdProfile", "LastModificationDate", "Login", "Password", "Status" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, "dev", "123", 1 });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Development department", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Development", 1 });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "Id", "DepartmentId", "Description", "IdCreationUser", "IdLastModificationUser", "LastModificationDate", "Name", "Status" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), null, "Development profile", new Guid("00000000-0000-0000-0000-000000000001"), null, null, "Development", 1 });

            migrationBuilder.Sql(@"DECLARE @sql NVARCHAR(MAX) = N'';

                                ;WITH x AS 
                                (
                                    SELECT DISTINCT obj = 
                                        QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' 
                                    + QUOTENAME(OBJECT_NAME(parent_object_id)) 
                                    FROM sys.foreign_keys
                                )
                                SELECT @sql += N'ALTER TABLE ' + obj + ' WITH CHECK CHECK CONSTRAINT ALL;
                                ' FROM x;

                                EXEC sp_executesql @sql;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @sql NVARCHAR(MAX) = N'';

                                ;WITH x AS 
                                (
                                    SELECT DISTINCT obj = 
                                        QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' 
                                    + QUOTENAME(OBJECT_NAME(parent_object_id)) 
                                    FROM sys.foreign_keys
                                )
                                SELECT @sql += N'ALTER TABLE ' + obj + ' WITH CHECK CHECK CONSTRAINT ALL;
                                ' FROM x;

                                EXEC sp_executesql @sql;");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
