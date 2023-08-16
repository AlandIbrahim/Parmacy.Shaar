using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class SetupDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Batch_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scientific_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drug_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Item_Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "delegates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delegates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_delegates_companies_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoice_No = table.Column<int>(type: "int", nullable: false),
                    Cu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_customer_Payments_customers_Cu_Id",
                        column: x => x.Cu_Id,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items_info",
                columns: table => new
                {
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity_in_Pharmacy = table.Column<float>(type: "real", nullable: false),
                    Quantity_in_Storage = table.Column<float>(type: "real", nullable: false),
                    Location_in_Pharmacy = table.Column<string>(type: "nchar(3)", maxLength: 3, nullable: false),
                    Location_in_Storage = table.Column<string>(type: "nchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items_info", x => new { x.Expiration_Date, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_items_info_items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items_sell",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_ID = table.Column<int>(type: "int", nullable: false),
                    Sale_Price = table.Column<float>(type: "real", nullable: false),
                    Purchase_Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items_sell", x => x.ID);
                    table.ForeignKey(
                        name: "FK_items_sell_items_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items_purchase",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receipt_No = table.Column<int>(type: "int", nullable: false),
                    Receipt_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item_ID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Quantity_Per_Item = table.Column<float>(type: "real", nullable: false),
                    Item_Bonus = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delegate_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items_purchase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_items_purchase_delegates_Delegate_ID",
                        column: x => x.Delegate_ID,
                        principalTable: "delegates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_purchase_items_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transfer_Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delegate_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_transfer_Companies_delegates_Delegate_ID",
                        column: x => x.Delegate_ID,
                        principalTable: "delegates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items_sale",
                columns: table => new
                {
                    Sale_Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Id = table.Column<int>(type: "int", nullable: false),
                    Cu_Id = table.Column<int>(type: "int", nullable: false),
                    Invoice_No = table.Column<int>(type: "int", nullable: false),
                    Invoice_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item_Quantity = table.Column<float>(type: "real", nullable: false),
                    Item_Price = table.Column<float>(type: "real", nullable: false),
                    Item_Discount = table.Column<float>(type: "real", nullable: false),
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items_sale", x => x.Sale_Item_Id);
                    table.ForeignKey(
                        name: "FK_items_sale_customers_Cu_Id",
                        column: x => x.Cu_Id,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_sale_items_sell_Sale_Id",
                        column: x => x.Sale_Id,
                        principalTable: "items_sell",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_Payments_Cu_Id",
                table: "customer_Payments",
                column: "Cu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_delegates_Company_ID",
                table: "delegates",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_items_info_Item_Id",
                table: "items_info",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_items_purchase_Delegate_ID",
                table: "items_purchase",
                column: "Delegate_ID");

            migrationBuilder.CreateIndex(
                name: "IX_items_purchase_Item_ID",
                table: "items_purchase",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Cu_Id",
                table: "items_sale",
                column: "Cu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Sale_Id",
                table: "items_sale",
                column: "Sale_Id");

            migrationBuilder.CreateIndex(
                name: "IX_items_sell_Item_ID",
                table: "items_sell",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_Companies_Delegate_ID",
                table: "transfer_Companies",
                column: "Delegate_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_Payments");

            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "items_info");

            migrationBuilder.DropTable(
                name: "items_purchase");

            migrationBuilder.DropTable(
                name: "items_sale");

            migrationBuilder.DropTable(
                name: "transfer_Companies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "items_sell");

            migrationBuilder.DropTable(
                name: "delegates");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
