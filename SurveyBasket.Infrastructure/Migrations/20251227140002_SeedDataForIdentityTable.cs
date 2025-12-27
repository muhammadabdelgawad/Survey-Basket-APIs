using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForIdentityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6", "5c5bd14c-9ea8-4026-8659-5f1e491ca98d", false, false, "Admin", "ADMIN" },
                    { "e0dc797e-c191-48f6-9c99-d3e1c88a688c", "8d6e7f42-5aca-4773-afcd-0286eb266a29", true, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "019b5fcd-1f24-7a71-a364-4e7449ceda4d", 0, "019b5fcc-f884-7497-ae6a-3076125a9607", "admin@survey-basket.com", true, "Survey Basket", "Admin", false, null, "ADMIN@SURVEY-BASKET.COM", "ADMIN@SURVEY-BASKET.COM", "AQAAAAIAAYagAAAAEH5xQXlgnJEFQkf5h265uylPI0pogI3eqCSeJ2JwagzKKBtSdEa69+lgF6R6b2MfCw==", null, false, "5461EC71052546A9971F56FE4CAAE7E3", false, "admin@survey-basket.com" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permissions", "polls:read", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 2, "Permissions", "polls:add", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 3, "Permissions", "polls:update", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 4, "Permissions", "polls:remove", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 5, "Permissions", "questions:read", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 6, "Permissions", "questions:add", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 7, "Permissions", "questions:update", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 8, "Permissions", "user:read", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 9, "Permissions", "user:add", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 10, "Permissions", "user:update", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 11, "Permissions", "roles:read", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 12, "Permissions", "roles:add", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 13, "Permissions", "roles:update", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" },
                    { 14, "Permissions", "results:read", "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6", "019b5fcd-1f24-7a71-a364-4e7449ceda4d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0dc797e-c191-48f6-9c99-d3e1c88a688c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6", "019b5fcd-1f24-7a71-a364-4e7449ceda4d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3c5e67f-b11d-4066-a26e-e6e0d9dd3cb6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "019b5fcd-1f24-7a71-a364-4e7449ceda4d");
        }
    }
}
