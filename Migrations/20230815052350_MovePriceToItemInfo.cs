using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class MovePriceToItemInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_Sales_invoices_Invoice_No",
                table: "item_Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_items_Purchase_delegates_Delegate_ID",
                table: "items_Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_items_Purchase_users_Employee_ID",
                table: "items_Purchase");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_items_Purchase_Delegate_ID",
                table: "items_Purchase");

            migrationBuilder.DropIndex(
                name: "IX_items_Purchase_Employee_ID",
                table: "items_Purchase");

            migrationBuilder.DropColumn(
                name: "Delegate_ID",
                table: "items_Purchase");

            migrationBuilder.DropColumn(
                name: "Employee_ID",
                table: "items_Purchase");

            migrationBuilder.DropColumn(
                name: "Item_Price",
                table: "item_Sales");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "items_Info",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "buy_Invoices",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Delegate_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buy_Invoices", x => x.No);
                    table.ForeignKey(
                        name: "FK_buy_Invoices_delegates_Delegate_Id",
                        column: x => x.Delegate_Id,
                        principalTable: "delegates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buy_Invoices_users_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sell_Invoices",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Cu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sell_Invoices", x => x.No);
                    table.ForeignKey(
                        name: "FK_sell_Invoices_customers_Cu_Id",
                        column: x => x.Cu_Id,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sell_Invoices_users_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_Purchase_Receipt_No",
                table: "items_Purchase",
                column: "Receipt_No");

            migrationBuilder.CreateIndex(
                name: "IX_buy_Invoices_Delegate_Id",
                table: "buy_Invoices",
                column: "Delegate_Id");

            migrationBuilder.CreateIndex(
                name: "IX_buy_Invoices_Employee_Id",
                table: "buy_Invoices",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_sell_Invoices_Cu_Id",
                table: "sell_Invoices",
                column: "Cu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_sell_Invoices_Employee_Id",
                table: "sell_Invoices",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_Sales_sell_Invoices_Invoice_No",
                table: "item_Sales",
                column: "Invoice_No",
                principalTable: "sell_Invoices",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_Purchase_buy_Invoices_Receipt_No",
                table: "items_Purchase",
                column: "Receipt_No",
                principalTable: "buy_Invoices",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_Sales_sell_Invoices_Invoice_No",
                table: "item_Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_items_Purchase_buy_Invoices_Receipt_No",
                table: "items_Purchase");

            migrationBuilder.DropTable(
                name: "buy_Invoices");

            migrationBuilder.DropTable(
                name: "sell_Invoices");

            migrationBuilder.DropIndex(
                name: "IX_items_Purchase_Receipt_No",
                table: "items_Purchase");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "items_Info");

            migrationBuilder.AddColumn<int>(
                name: "Delegate_ID",
                table: "items_Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Employee_ID",
                table: "items_Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Item_Price",
                table: "item_Sales",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cu_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Buy_Or_Sell = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.No);
                    table.ForeignKey(
                        name: "FK_invoices_customers_Cu_Id",
                        column: x => x.Cu_Id,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_users_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_Purchase_Delegate_ID",
                table: "items_Purchase",
                column: "Delegate_ID");

            migrationBuilder.CreateIndex(
                name: "IX_items_Purchase_Employee_ID",
                table: "items_Purchase",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_Cu_Id",
                table: "invoices",
                column: "Cu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_Employee_Id",
                table: "invoices",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_Sales_invoices_Invoice_No",
                table: "item_Sales",
                column: "Invoice_No",
                principalTable: "invoices",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_Purchase_delegates_Delegate_ID",
                table: "items_Purchase",
                column: "Delegate_ID",
                principalTable: "delegates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_Purchase_users_Employee_ID",
                table: "items_Purchase",
                column: "Employee_ID",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
