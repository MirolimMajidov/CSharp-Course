using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("15c2975d-892c-4238-865e-bca7488cf7d3"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("6490761c-bee1-413a-a842-e6c6bb66d7ba"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("a341601d-1970-4a15-95b2-ca18cc0887df"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("ebed67e5-b924-4074-8a1a-274d5a47ab19"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("8240ad02-bd8c-48b2-a7da-099c21229c2a"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("dcb54495-ea6b-4be5-9a87-fbeee91e03d4"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("244ebe0b-e94c-4464-b30f-338a21580cf8"));

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Persons",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"), "Station", new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b") },
                    { new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"), "Guliston, Glavnoy", new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("0bf276fc-d3dc-4aee-a86d-b68da5cd659b"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"), "Client", "Rahmatillo", "Azamov", 0 },
                    { new Guid("0c0b0f17-f960-4195-8578-1a4e1c3de833"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"), "Client", "Nabijon", "Azamov", 0 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("6f8fcd85-9f54-4308-b337-3df159256be3"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"), "Worker", "Abdurasul", "Abdurahmonov", null },
                    { new Guid("f5e1467e-6e58-4df2-8a41-4bcd6b888c72"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"), "Worker", "Yoqubjon", "Ahmedov", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("0bf276fc-d3dc-4aee-a86d-b68da5cd659b"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("0c0b0f17-f960-4195-8578-1a4e1c3de833"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("6f8fcd85-9f54-4308-b337-3df159256be3"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("f5e1467e-6e58-4df2-8a41-4bcd6b888c72"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "LastName");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("244ebe0b-e94c-4464-b30f-338a21580cf8"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("8240ad02-bd8c-48b2-a7da-099c21229c2a"), "Station", new Guid("244ebe0b-e94c-4464-b30f-338a21580cf8") },
                    { new Guid("dcb54495-ea6b-4be5-9a87-fbeee91e03d4"), "Guliston, Glavnoy", new Guid("244ebe0b-e94c-4464-b30f-338a21580cf8") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "State" },
                values: new object[] { new Guid("15c2975d-892c-4238-865e-bca7488cf7d3"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8240ad02-bd8c-48b2-a7da-099c21229c2a"), "Client", "Nabijon", "Azamov", 0 });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { new Guid("6490761c-bee1-413a-a842-e6c6bb66d7ba"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("dcb54495-ea6b-4be5-9a87-fbeee91e03d4"), "Worker", "Abdurasul", "Abdurahmonov", null },
                    { new Guid("a341601d-1970-4a15-95b2-ca18cc0887df"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8240ad02-bd8c-48b2-a7da-099c21229c2a"), "Worker", "Yoqubjon", "Ahmedov", null }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "State" },
                values: new object[] { new Guid("ebed67e5-b924-4074-8a1a-274d5a47ab19"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("dcb54495-ea6b-4be5-9a87-fbeee91e03d4"), "Client", "Rahmatillo", "Azamov", 0 });
        }
    }
}
