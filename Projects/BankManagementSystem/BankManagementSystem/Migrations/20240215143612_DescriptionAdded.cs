using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("5c0848b3-a489-4154-afd4-b5a9715dbb22"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("a15c1ef7-e5d2-4666-aba0-6406f4c2fde8"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("baee1320-f9b9-48d8-9cc4-45fd804d9191"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("d7578cc6-c0db-439b-897a-584f8e4a2f2e"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("3d51bfa1-fafa-4675-92fb-5fc5fe571241"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("d9da1e6b-29d5-423e-ad31-2a66e790fa07"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("f00d58fe-9386-46d4-a76c-3fffcaaaffb8"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("f00d58fe-9386-46d4-a76c-3fffcaaaffb8"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("3d51bfa1-fafa-4675-92fb-5fc5fe571241"), "Station", new Guid("f00d58fe-9386-46d4-a76c-3fffcaaaffb8") },
                    { new Guid("d9da1e6b-29d5-423e-ad31-2a66e790fa07"), "Guliston, Glavnoy", new Guid("f00d58fe-9386-46d4-a76c-3fffcaaaffb8") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { new Guid("5c0848b3-a489-4154-afd4-b5a9715dbb22"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3d51bfa1-fafa-4675-92fb-5fc5fe571241"), "Worker", "Yoqubjon", "Ahmedov", null },
                    { new Guid("a15c1ef7-e5d2-4666-aba0-6406f4c2fde8"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d9da1e6b-29d5-423e-ad31-2a66e790fa07"), "Worker", "Abdurasul", "Abdurahmonov", null }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "State" },
                values: new object[,]
                {
                    { new Guid("baee1320-f9b9-48d8-9cc4-45fd804d9191"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3d51bfa1-fafa-4675-92fb-5fc5fe571241"), "Client", "Nabijon", "Azamov", 0 },
                    { new Guid("d7578cc6-c0db-439b-897a-584f8e4a2f2e"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d9da1e6b-29d5-423e-ad31-2a66e790fa07"), "Client", "Rahmatillo", "Azamov", 0 }
                });
        }
    }
}
