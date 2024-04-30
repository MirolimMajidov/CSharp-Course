using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AgeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("130bb2d9-a0bf-4f42-b78c-627b2c10af4c"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("4a9d760a-4f5b-4e17-b2c6-267924b5b685"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("58d357c2-d396-4cec-b9ef-5dfa9d0da564"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("88cc7d6f-5507-4483-a60a-f3257fa36389"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("644585a2-bb09-4b82-850e-073cf5a621da"));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("ae07c3f9-2838-4631-abc8-aa15880b3142"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("155be66e-afc4-4b9b-aa38-ae0f3539f27c"), "Guliston, Glavnoy", new Guid("ae07c3f9-2838-4631-abc8-aa15880b3142") },
                    { new Guid("2f845028-c6af-412c-a463-7d07a81ffa4e"), "Station", new Guid("ae07c3f9-2838-4631-abc8-aa15880b3142") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Age", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Role", "State", "Username" },
                values: new object[] { new Guid("0ee7fb17-4260-453a-a7f7-b8fa2f9e2db4"), null, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2f845028-c6af-412c-a463-7d07a81ffa4e"), "Client", "Nabijon", "Azamov", "123", null, "admin", 0, "Nabijon" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Age", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Responsibility", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("bc7ca18f-9bad-4f89-9735-0181179c99ce"), null, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2f845028-c6af-412c-a463-7d07a81ffa4e"), "Worker", "Yoqubjon", "Ahmedov", null, null, null, null, null },
                    { new Guid("d423cf14-c03b-4cd4-92f2-e80888449492"), null, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("155be66e-afc4-4b9b-aa38-ae0f3539f27c"), "Worker", "Abdurasul", "Abdurahmonov", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Age", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Role", "State", "Username" },
                values: new object[] { new Guid("ebc5475a-1a9b-4a88-9b97-b37a6f106ada"), null, 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("155be66e-afc4-4b9b-aa38-ae0f3539f27c"), "Client", "Rahmatillo", "Azamov", "123", null, "editor", 0, "Tillo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("0ee7fb17-4260-453a-a7f7-b8fa2f9e2db4"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("bc7ca18f-9bad-4f89-9735-0181179c99ce"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("d423cf14-c03b-4cd4-92f2-e80888449492"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("ebc5475a-1a9b-4a88-9b97-b37a6f106ada"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("155be66e-afc4-4b9b-aa38-ae0f3539f27c"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("2f845028-c6af-412c-a463-7d07a81ffa4e"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("ae07c3f9-2838-4631-abc8-aa15880b3142"));

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Persons");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("644585a2-bb09-4b82-850e-073cf5a621da"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"), "Guliston, Glavnoy", new Guid("644585a2-bb09-4b82-850e-073cf5a621da") },
                    { new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"), "Station", new Guid("644585a2-bb09-4b82-850e-073cf5a621da") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Role", "State", "Username" },
                values: new object[] { new Guid("130bb2d9-a0bf-4f42-b78c-627b2c10af4c"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"), "Client", "Rahmatillo", "Azamov", "123", null, "editor", 0, "Tillo" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Responsibility", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("4a9d760a-4f5b-4e17-b2c6-267924b5b685"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"), "Worker", "Abdurasul", "Abdurahmonov", null, null, null, null, null },
                    { new Guid("58d357c2-d396-4cec-b9ef-5dfa9d0da564"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"), "Worker", "Yoqubjon", "Ahmedov", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Role", "State", "Username" },
                values: new object[] { new Guid("88cc7d6f-5507-4483-a60a-f3257fa36389"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"), "Client", "Nabijon", "Azamov", "123", null, "admin", 0, "Nabijon" });
        }
    }
}
