using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityModel.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "json", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "text", nullable: false),
                    User_Id = table.Column<string>(type: "text", nullable: false),
                    Customer_Id = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: true),
                    Vat = table.Column<long>(type: "bigint", nullable: true),
                    Discount_Id = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "json", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone_Number = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Ref_Name = table.Column<string>(type: "text", nullable: true),
                    Ref_Phone_Number = table.Column<int>(type: "integer", nullable: true),
                    License_plate = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "json", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Campaign_Name = table.Column<string>(type: "text", nullable: false),
                    Discount_Value = table.Column<int>(type: "integer", nullable: false),
                    Info = table.Column<string>(type: "json", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Product_Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    Import_Price = table.Column<float>(type: "real", nullable: true),
                    Sale_Price = table.Column<float>(type: "real", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    Product_Code = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "json", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Uid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
