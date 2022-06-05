using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBlog.DataLayer.Migrations
{
    public partial class InitCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "320a89a9-be8d-4ee5-8c4a-d15c6fd90083");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4d8ebd1f-64da-4bd3-b05b-5cdcba61a915");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08a867ec-cbc3-49fb-b149-4b0de4a0433f", "AQAAAAEAACcQAAAAEG/09kTB2bzjVZVVwDR7sk1N5EuLe8GvfcdgQqD3/nzCkbmVXQ+hy4YSOccHDaG/Sg==", "cffe6864-f14e-4ce5-935d-b1d193fb48f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee6d9bfd-d453-47cb-9708-1d282b0bc40e", "AQAAAAEAACcQAAAAEJBwSg+shxfhDBcxMuhLPVOtE/ykvZkDfbXjHYTcb21BuGD660/RsnfvtyBCALfubg==", "ccd27e3f-2a48-4e1c-8d1c-017612ccb314" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 40, 1, 218, DateTimeKind.Local).AddTicks(4441), new DateTime(2022, 5, 23, 16, 40, 1, 218, DateTimeKind.Local).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 40, 1, 218, DateTimeKind.Local).AddTicks(5878), new DateTime(2022, 5, 23, 16, 40, 1, 218, DateTimeKind.Local).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 40, 1, 218, DateTimeKind.Local).AddTicks(5888), new DateTime(2022, 5, 23, 16, 40, 1, 218, DateTimeKind.Local).AddTicks(5890) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d26d6c5c-5dc9-443f-8c14-4e0a5e54f30b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "af26f0e7-12fc-44da-bb24-dd6b0feafebc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ca0992d-8310-4ede-8d49-eb46cb869229", "AQAAAAEAACcQAAAAEDChbNBzgerZ4IHubfl5VZGKua5DUApHlbf3YFVYsqCnkEbBrfrVBakjvsBS8WphXw==", "c09a2a88-b704-4425-a6c7-b443ca2fe874" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3efb579b-c39a-4bc9-b25c-ae0692867d91", "AQAAAAEAACcQAAAAEGYfZY89qbPvjlxHSqP5REfgJcvtyvE+jAEp6g+yXV7/lS8+W+cJBF4MzZZKt8u50A==", "1e7270b2-522d-47a7-b05b-e7bc7e8561e3" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 33, 30, 607, DateTimeKind.Local).AddTicks(5325), new DateTime(2022, 5, 23, 16, 33, 30, 607, DateTimeKind.Local).AddTicks(5860) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 33, 30, 607, DateTimeKind.Local).AddTicks(6833), new DateTime(2022, 5, 23, 16, 33, 30, 607, DateTimeKind.Local).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 33, 30, 607, DateTimeKind.Local).AddTicks(6842), new DateTime(2022, 5, 23, 16, 33, 30, 607, DateTimeKind.Local).AddTicks(6844) });
        }
    }
}
