using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366cddc3-8ffb-4b6c-9df7-aaf99d737444",
                column: "ConcurrencyStamp",
                value: "64a27f53-bb6c-4d1a-9d18-55f8f7195f86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c65a4ecb-89b0-4c14-8a90-4bafea94d642",
                column: "ConcurrencyStamp",
                value: "8f7c0d81-0b90-4a03-9156-86c27508731c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14e20b2-f833-42c5-bb8a-abfac472a59c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc603d7-541c-4f07-b97f-3480ce9a7bf1", "AQAAAAEAACcQAAAAECvSE9OwXFv1LlHRQ44aZgF4yDKH4RKkA/Xwehqbgpq4RrKAAxK5dp2b37EQujsT0A==", "9e5a9078-f073-4a56-a3e3-88fb9677363e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366cddc3-8ffb-4b6c-9df7-aaf99d737444",
                column: "ConcurrencyStamp",
                value: "82df0b3b-540d-49b6-85e6-2b131903af1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c65a4ecb-89b0-4c14-8a90-4bafea94d642",
                column: "ConcurrencyStamp",
                value: "c6b4a364-784a-4914-8eb4-1e99c76b4f24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14e20b2-f833-42c5-bb8a-abfac472a59c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01866e90-5f79-4fa9-ad74-b3427aadb91b", "AQAAAAEAACcQAAAAEBVFiNgx9YbedjgApMOLJtOmXWhU8/zmaw+OM/w+TlW6XTO61XTFvDRwlagac73RpQ==", "b7a7f0ef-b47b-4f66-94e7-6b20026bea29" });
        }
    }
}
