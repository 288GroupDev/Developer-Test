using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _288Group.ECommerceShop.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ErrorMessage = table.Column<string>(type: "TEXT", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "TEXT", nullable: true),
                    InnerExceptionMessage = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiscountCodes",
                columns: new[] { "Id", "Code", "DateCreatedUtc", "DiscountPercentage" },
                values: new object[] { 1L, "EverythingIsAwesome", new DateTime(2021, 5, 31, 21, 19, 9, 778, DateTimeKind.Utc).AddTicks(3041), 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreatedUtc", "Name", "Price" },
                values: new object[] { 1L, new DateTime(2021, 5, 31, 21, 19, 9, 776, DateTimeKind.Utc).AddTicks(1210), "Wooden Spoon", 2.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreatedUtc", "Name", "Price" },
                values: new object[] { 2L, new DateTime(2021, 5, 31, 21, 19, 9, 777, DateTimeKind.Utc).AddTicks(9800), "Dax Cobra", 28500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreatedUtc", "Name", "Price" },
                values: new object[] { 3L, new DateTime(2021, 5, 31, 21, 19, 9, 778, DateTimeKind.Utc).AddTicks(215), "Sunglasses", 6.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreatedUtc", "Name", "Price" },
                values: new object[] { 4L, new DateTime(2021, 5, 31, 21, 19, 9, 778, DateTimeKind.Utc).AddTicks(236), "Kite", 15.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreatedUtc", "Name", "Price" },
                values: new object[] { 5L, new DateTime(2021, 5, 31, 21, 19, 9, 778, DateTimeKind.Utc).AddTicks(249), "LEGO 75257 Star Wars Millennium Falcon", 112.5m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreatedUtc", "Password", "Username" },
                values: new object[] { 1L, new DateTime(2021, 5, 31, 21, 19, 9, 778, DateTimeKind.Utc).AddTicks(1509), "ABC", "Fred" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreatedUtc", "Password", "Username" },
                values: new object[] { 2L, new DateTime(2021, 5, 31, 21, 19, 9, 778, DateTimeKind.Utc).AddTicks(1755), "ABC", "James" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
