using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class cardAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("41f8dc75-e648-4e64-a066-6aff4dc1ffa5"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("b11070bc-892a-45c0-a352-49e952466825"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("b5842ab3-d780-47bb-937c-45eac371bbdc"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("ddcc95c9-790b-40ef-a380-7bb659667dcd"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("9514e7df-fcd3-4a25-bd3d-1bf86e7bfc21"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("b14e3433-e7e5-4f02-88b1-d7f3adbd6be6"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("cc85f9d6-baba-486b-b7f7-4a45f087fbe6"));

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    HolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

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

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("cc85f9d6-baba-486b-b7f7-4a45f087fbe6"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("9514e7df-fcd3-4a25-bd3d-1bf86e7bfc21"), "Station", new Guid("cc85f9d6-baba-486b-b7f7-4a45f087fbe6") },
                    { new Guid("b14e3433-e7e5-4f02-88b1-d7f3adbd6be6"), "Guliston, Glavnoy", new Guid("cc85f9d6-baba-486b-b7f7-4a45f087fbe6") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Responsibility", "Role", "Username" },
                values: new object[] { new Guid("41f8dc75-e648-4e64-a066-6aff4dc1ffa5"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9514e7df-fcd3-4a25-bd3d-1bf86e7bfc21"), "Worker", "Yoqubjon", "Ahmedov", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Role", "State", "Username" },
                values: new object[] { new Guid("b11070bc-892a-45c0-a352-49e952466825"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b14e3433-e7e5-4f02-88b1-d7f3adbd6be6"), "Client", "Rahmatillo", "Azamov", "123", null, "editor", 0, "Tillo" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Responsibility", "Role", "Username" },
                values: new object[] { new Guid("b5842ab3-d780-47bb-937c-45eac371bbdc"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b14e3433-e7e5-4f02-88b1-d7f3adbd6be6"), "Worker", "Abdurasul", "Abdurahmonov", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Password", "RefreshToken", "Role", "State", "Username" },
                values: new object[] { new Guid("ddcc95c9-790b-40ef-a380-7bb659667dcd"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9514e7df-fcd3-4a25-bd3d-1bf86e7bfc21"), "Client", "Nabijon", "Azamov", "123", null, "admin", 0, "Nabijon" });
        }
    }
}
