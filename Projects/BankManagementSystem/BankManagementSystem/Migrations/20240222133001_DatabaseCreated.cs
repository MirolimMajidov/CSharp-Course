using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Persons_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("e7ed3dda-76b7-497f-8d7e-a396e51d3583"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("1cfbe8d8-edbf-4152-9aac-7106d481d08e"), "Station", new Guid("e7ed3dda-76b7-497f-8d7e-a396e51d3583") },
                    { new Guid("8aed7495-7e2f-49db-b0ac-ca0d415cb4aa"), "Guliston, Glavnoy", new Guid("e7ed3dda-76b7-497f-8d7e-a396e51d3583") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "State" },
                values: new object[,]
                {
                    { new Guid("0a8bb99b-49a4-47ac-bc90-869b61031788"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1cfbe8d8-edbf-4152-9aac-7106d481d08e"), "Client", "Nabijon", "Azamov", 0 },
                    { new Guid("3f52dd9a-2ef9-4ce4-ac53-24d35b172f38"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8aed7495-7e2f-49db-b0ac-ca0d415cb4aa"), "Client", "Rahmatillo", "Azamov", 0 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { new Guid("6b2cbb85-259f-44b6-aa98-7d1ea03b09b3"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1cfbe8d8-edbf-4152-9aac-7106d481d08e"), "Worker", "Yoqubjon", "Ahmedov", null },
                    { new Guid("b2170c92-ec18-47f9-b2ec-93a8b20ecbe9"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8aed7495-7e2f-49db-b0ac-ca0d415cb4aa"), "Worker", "Abdurasul", "Abdurahmonov", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("0a8bb99b-49a4-47ac-bc90-869b61031788"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("3f52dd9a-2ef9-4ce4-ac53-24d35b172f38"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("6b2cbb85-259f-44b6-aa98-7d1ea03b09b3"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("b2170c92-ec18-47f9-b2ec-93a8b20ecbe9"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("1cfbe8d8-edbf-4152-9aac-7106d481d08e"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("8aed7495-7e2f-49db-b0ac-ca0d415cb4aa"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("e7ed3dda-76b7-497f-8d7e-a396e51d3583"));

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
    }
}
