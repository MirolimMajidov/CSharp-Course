using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class DBCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branchs_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Nabijon"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName2 = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT(FirstName, ' ', LastName)"),
                    Birthday = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("172a9611-9f14-4fb5-bc9d-76b50545ed22"), "Guliston", "Eskhata" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Address", "BankId" },
                values: new object[,]
                {
                    { new Guid("41751cac-fd58-4f12-ae0c-a40bccf8f55a"), "Guliston, Glavnoy", new Guid("172a9611-9f14-4fb5-bc9d-76b50545ed22") },
                    { new Guid("ef39d9c7-83ef-4858-b75d-a34461f20a2f"), "Station", new Guid("172a9611-9f14-4fb5-bc9d-76b50545ed22") }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "State" },
                values: new object[] { new Guid("38b086da-8316-4a65-a7da-d31db12f5730"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef39d9c7-83ef-4858-b75d-a34461f20a2f"), "Client", "Nabijon", "Azamov", 0 });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Role" },
                values: new object[] { new Guid("3df470c0-15aa-4591-8639-f15b4e8a1ca4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef39d9c7-83ef-4858-b75d-a34461f20a2f"), "Worker", "Yoqubjon", "Ahmedov", null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "State" },
                values: new object[] { new Guid("3e7ff9f5-7935-4cb0-ade5-61974423a47b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("41751cac-fd58-4f12-ae0c-a40bccf8f55a"), "Client", "Rahmatillo", "Azamov", 0 });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthday", "BranchId", "Discriminator", "FirstName", "LastName", "Role" },
                values: new object[] { new Guid("edc183f0-2f35-4f48-8053-8fd53c9f021c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("41751cac-fd58-4f12-ae0c-a40bccf8f55a"), "Worker", "Abdurasul", "Abdurahmonov", null });

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_BankId",
                table: "Branchs",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BankId",
                table: "Departments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BranchId",
                table: "Persons",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
