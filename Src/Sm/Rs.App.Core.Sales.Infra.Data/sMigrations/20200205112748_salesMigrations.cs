using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rs.App.Core.Sales.Infra.Data.sMigrations
{
    public partial class salesMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sales.Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales.Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales.Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales.Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales.Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales.SalePeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales.SalePeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales.Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    SalePersionId = table.Column<Guid>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    SalePersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales.Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales.Sales_sales.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "sales.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales.Sales_sales.SalePeople_SalePersonId",
                        column: x => x.SalePersonId,
                        principalTable: "sales.SalePeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales.Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales.Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales.Orders_sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales.OrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales.OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales.OrderProducts_sales.Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "sales.Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales.OrderProducts_sales.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "sales.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sales.OrderProducts_OrderId",
                table: "sales.OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_sales.OrderProducts_ProductId",
                table: "sales.OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_sales.Orders_SaleId",
                table: "sales.Orders",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_sales.Sales_CustomerId",
                table: "sales.Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_sales.Sales_SalePersonId",
                table: "sales.Sales",
                column: "SalePersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "sales.OrderProducts");

            migrationBuilder.DropTable(
                name: "sales.Orders");

            migrationBuilder.DropTable(
                name: "sales.Products");

            migrationBuilder.DropTable(
                name: "sales.Sales");

            migrationBuilder.DropTable(
                name: "sales.Customers");

            migrationBuilder.DropTable(
                name: "sales.SalePeople");
        }
    }
}
