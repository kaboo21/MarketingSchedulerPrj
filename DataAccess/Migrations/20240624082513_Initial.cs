using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Deposit = table.Column<int>(type: "INTEGER", nullable: false),
                    IsNew = table.Column<bool>(type: "INTEGER", nullable: false),
                    CampainSendedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CampainSendedDate", "City", "Deposit", "Gender", "IsNew" },
                values: new object[,]
                {
                    { 1, 53, null, "London", 104, 0, false },
                    { 2, 44, null, "New York", 209, 1, true },
                    { 3, 36, null, "New York", 208, 0, true },
                    { 4, 87, null, "London", 134, 1, false },
                    { 5, 54, null, "Paris", 123, 0, true },
                    { 6, 45, null, "New York", 210, 1, true },
                    { 7, 49, null, "Tel-Aviv", 174, 1, false },
                    { 8, 35, null, "Paris", 52, 0, true },
                    { 9, 61, null, "Tel-Aviv", 151, 0, false },
                    { 10, 78, null, "Paris", 57, 0, false },
                    { 11, 41, null, "New York", 131, 1, false },
                    { 12, 32, null, "Tel-Aviv", 154, 1, true },
                    { 13, 62, null, "Paris", 135, 1, false },
                    { 14, 67, null, "Tel-Aviv", 153, 0, true },
                    { 15, 68, null, "London", 241, 1, true },
                    { 16, 41, null, "London", 134, 0, false },
                    { 17, 46, null, "London", 212, 1, false },
                    { 18, 77, null, "Tel-Aviv", 97, 1, true },
                    { 19, 51, null, "London", 141, 0, true },
                    { 20, 80, null, "Paris", 189, 0, false },
                    { 21, 31, null, "Tel-Aviv", 134, 1, true },
                    { 22, 80, null, "Tel-Aviv", 81, 1, false },
                    { 23, 36, null, "London", 237, 1, true },
                    { 24, 65, null, "Tel-Aviv", 119, 1, false },
                    { 25, 72, null, "Tel-Aviv", 139, 0, false },
                    { 26, 64, null, "Tel-Aviv", 128, 0, true },
                    { 27, 29, null, "London", 76, 0, true },
                    { 28, 25, null, "London", 203, 0, true },
                    { 29, 77, null, "New York", 54, 0, true },
                    { 30, 79, null, "Paris", 165, 1, true },
                    { 31, 26, null, "Paris", 143, 1, true },
                    { 32, 74, null, "London", 61, 1, false },
                    { 33, 74, null, "New York", 103, 0, false },
                    { 34, 46, null, "New York", 121, 1, true },
                    { 35, 47, null, "New York", 214, 1, false },
                    { 36, 78, null, "New York", 111, 1, false },
                    { 37, 46, null, "New York", 223, 1, true },
                    { 38, 26, null, "New York", 78, 1, true },
                    { 39, 49, null, "Tel-Aviv", 60, 1, false },
                    { 40, 74, null, "New York", 53, 1, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
