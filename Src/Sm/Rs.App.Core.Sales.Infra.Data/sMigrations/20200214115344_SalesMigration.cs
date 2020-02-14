using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rs.App.Core.Sales.Infra.Data.sMigrations
{
    public partial class SalesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo.Sale");

            migrationBuilder.CreateTable(
                name: "Audits",
                schema: "dbo.Sale",
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
                name: "Customers",
                schema: "dbo.Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo.Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalePeople",
                schema: "dbo.Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "dbo.Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    SalePersonId = table.Column<Guid>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo.Sale",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_SalePeople_SalePersonId",
                        column: x => x.SalePersonId,
                        principalSchema: "dbo.Sale",
                        principalTable: "SalePeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo.Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "dbo.Sale",
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "dbo.Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo.Sale",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo.Sale",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                schema: "dbo.Sale",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                schema: "dbo.Sale",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SaleId",
                schema: "dbo.Sale",
                table: "Orders",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                schema: "dbo.Sale",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalePersonId",
                schema: "dbo.Sale",
                table: "Sales",
                column: "SalePersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits",
                schema: "dbo.Sale");

            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "dbo.Sale");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo.Sale");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo.Sale");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "dbo.Sale");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "dbo.Sale");

            migrationBuilder.DropTable(
                name: "SalePeople",
                schema: "dbo.Sale");
        }
    }
}
