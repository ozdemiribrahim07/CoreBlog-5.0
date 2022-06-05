using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBlog.DataLayer.Migrations
{
    public partial class InitCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f54219f2-723a-4dd2-8075-b8b787cb36f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e8af7dd3-9d2b-4ed2-a1b9-e7e0e91ed941");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f50a0977-3058-4e60-83a8-d516b13af405", "AQAAAAEAACcQAAAAEN8arntbwUOajYDSHKiSEEwR9zVUQ0SNZ0/2eo5ZKI3ON96R9nh+yHqrmoayW9O8jw==", "ca52f7e0-52b8-40cc-8b9e-d1db696beeda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1faa2eab-d971-49b4-b282-f3874fe19fc3", "AQAAAAEAACcQAAAAEGJmqo+k0uPljKkB11h5ioXyrLacmQNsrCJMVsvp6CBWjq5+xQdMDPVS2DMIlU1WBw==", "6bc7e1d9-5d3a-4618-9996-681a5eeb1c23" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogContent", "BlogImage", "BlogTitle", "CategoryId", "CommentCount", "CreatedName", "Date", "DateCreated", "EditDate", "EditedName", "IsActive", "IsDeleted", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "first.jpg", ".NET 5.0 Çıktı!", 1, 1, "InitFirst", new DateTime(2022, 5, 23, 16, 41, 19, 127, DateTimeKind.Local).AddTicks(4699), new DateTime(2022, 5, 23, 16, 41, 19, 127, DateTimeKind.Local).AddTicks(8210), new DateTime(2022, 5, 23, 16, 41, 19, 127, DateTimeKind.Local).AddTicks(9022), "InitFirst", true, false, 1, 50 },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "first.jpg", "Python", 2, 1, "InitFirst", new DateTime(2022, 5, 23, 16, 41, 19, 128, DateTimeKind.Local).AddTicks(542), new DateTime(2022, 5, 23, 16, 41, 19, 128, DateTimeKind.Local).AddTicks(546), new DateTime(2022, 5, 23, 16, 41, 19, 128, DateTimeKind.Local).AddTicks(548), "InitFirst", true, false, 1, 75 },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "first.jpg", "Java", 3, 1, "InitFirst", new DateTime(2022, 5, 23, 16, 41, 19, 128, DateTimeKind.Local).AddTicks(559), new DateTime(2022, 5, 23, 16, 41, 19, 128, DateTimeKind.Local).AddTicks(563), new DateTime(2022, 5, 23, 16, 41, 19, 128, DateTimeKind.Local).AddTicks(565), "InitFirst", true, false, 1, 100 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 41, 19, 135, DateTimeKind.Local).AddTicks(9670), new DateTime(2022, 5, 23, 16, 41, 19, 135, DateTimeKind.Local).AddTicks(9706) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 41, 19, 135, DateTimeKind.Local).AddTicks(9744), new DateTime(2022, 5, 23, 16, 41, 19, 135, DateTimeKind.Local).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EditDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 41, 19, 135, DateTimeKind.Local).AddTicks(9757), new DateTime(2022, 5, 23, 16, 41, 19, 135, DateTimeKind.Local).AddTicks(9763) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
