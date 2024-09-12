using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Data.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366cddc3-8ffb-4b6c-9df7-aaf99d737444",
                column: "ConcurrencyStamp",
                value: "279dda9e-b0a2-453f-88af-f9972e82e1d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c65a4ecb-89b0-4c14-8a90-4bafea94d642",
                column: "ConcurrencyStamp",
                value: "88a5ac20-ca8a-427d-885c-d07309f8e028");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14e20b2-f833-42c5-bb8a-abfac472a59c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "693f581d-8f4e-437b-a5b2-f1aacd551623", "AQAAAAEAACcQAAAAEP+pQo69S9QzcgcnvJjI1yZ85HW7y7AAZjPs/wGsz+ZwROhviWvSTNbbQnj53FeEiQ==", "fd35a204-7ed0-46be-92ca-82851b710978" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
