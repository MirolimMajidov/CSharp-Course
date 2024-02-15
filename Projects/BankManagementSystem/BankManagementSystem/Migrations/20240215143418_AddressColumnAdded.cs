﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddressColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("38b086da-8316-4a65-a7da-d31db12f5730"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("3df470c0-15aa-4591-8639-f15b4e8a1ca4"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("3e7ff9f5-7935-4cb0-ade5-61974423a47b"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("edc183f0-2f35-4f48-8053-8fd53c9f021c"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("41751cac-fd58-4f12-ae0c-a40bccf8f55a"));

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: new Guid("ef39d9c7-83ef-4858-b75d-a34461f20a2f"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("172a9611-9f14-4fb5-bc9d-76b50545ed22"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Persons");

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
        }
    }
}
