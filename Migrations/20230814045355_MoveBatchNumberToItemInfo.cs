using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class MoveBatchNumberToItemInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_info_items_Item_Id",
                table: "items_info");

            migrationBuilder.DropForeignKey(
                name: "FK_items_purchase_delegates_Delegate_ID",
                table: "items_purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_items_purchase_items_Item_ID",
                table: "items_purchase");

            migrationBuilder.DropTable(
                name: "items_sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items_purchase",
                table: "items_purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items_info",
                table: "items_info");

            migrationBuilder.DropColumn(
                name: "Batch_no",
                table: "items");

            migrationBuilder.RenameTable(
                name: "items_purchase",
                newName: "items_Purchase");

            migrationBuilder.RenameTable(
                name: "items_info",
                newName: "items_Info");

            migrationBuilder.RenameIndex(
                name: "IX_items_purchase_Item_ID",
                table: "items_Purchase",
                newName: "IX_items_Purchase_Item_ID");

            migrationBuilder.RenameIndex(
                name: "IX_items_purchase_Delegate_ID",
                table: "items_Purchase",
                newName: "IX_items_Purchase_Delegate_ID");

            migrationBuilder.RenameIndex(
                name: "IX_items_info_Item_Id",
                table: "items_Info",
                newName: "IX_items_Info_Item_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration_Date",
                table: "items_Purchase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "batch_no",
                table: "items_Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Buy_Or_Sell",
                table: "invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_items_Purchase",
                table: "items_Purchase",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items_Info",
                table: "items_Info",
                columns: new[] { "Expiration_Date", "Item_Id" });

            migrationBuilder.CreateTable(
                name: "item_Sales",
                columns: table => new
                {
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Sale_Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_No = table.Column<int>(type: "int", nullable: false),
                    Item_Quantity = table.Column<float>(type: "real", nullable: false),
                    Item_Price = table.Column<float>(type: "real", nullable: false),
                    Item_Discount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_Sales", x => x.Sale_Item_Id);
                    table.ForeignKey(
                        name: "FK_item_Sales_invoices_Invoice_No",
                        column: x => x.Invoice_No,
                        principalTable: "invoices",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_Sales_items_Info_Expiration_Date_Item_Id",
                        columns: x => new { x.Expiration_Date, x.Item_Id },
                        principalTable: "items_Info",
                        principalColumns: new[] { "Expiration_Date", "Item_Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_Sales_Expiration_Date_Item_Id",
                table: "item_Sales",
                columns: new[] { "Expiration_Date", "Item_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_item_Sales_Invoice_No",
                table: "item_Sales",
                column: "Invoice_No");

            migrationBuilder.AddForeignKey(
                name: "FK_items_Info_items_Item_Id",
                table: "items_Info",
                column: "Item_Id",
                principalTable: "items",
                principalColumn: "Item_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_Purchase_delegates_Delegate_ID",
                table: "items_Purchase",
                column: "Delegate_ID",
                principalTable: "delegates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_Purchase_items_Item_ID",
                table: "items_Purchase",
                column: "Item_ID",
                principalTable: "items",
                principalColumn: "Item_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_Info_items_Item_Id",
                table: "items_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_items_Purchase_delegates_Delegate_ID",
                table: "items_Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_items_Purchase_items_Item_ID",
                table: "items_Purchase");

            migrationBuilder.DropTable(
                name: "item_Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items_Purchase",
                table: "items_Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items_Info",
                table: "items_Info");

            migrationBuilder.DropColumn(
                name: "Expiration_Date",
                table: "items_Purchase");

            migrationBuilder.DropColumn(
                name: "batch_no",
                table: "items_Info");

            migrationBuilder.DropColumn(
                name: "Buy_Or_Sell",
                table: "invoices");

            migrationBuilder.RenameTable(
                name: "items_Purchase",
                newName: "items_purchase");

            migrationBuilder.RenameTable(
                name: "items_Info",
                newName: "items_info");

            migrationBuilder.RenameIndex(
                name: "IX_items_Purchase_Item_ID",
                table: "items_purchase",
                newName: "IX_items_purchase_Item_ID");

            migrationBuilder.RenameIndex(
                name: "IX_items_Purchase_Delegate_ID",
                table: "items_purchase",
                newName: "IX_items_purchase_Delegate_ID");

            migrationBuilder.RenameIndex(
                name: "IX_items_Info_Item_Id",
                table: "items_info",
                newName: "IX_items_info_Item_Id");

            migrationBuilder.AddColumn<string>(
                name: "Batch_no",
                table: "items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items_purchase",
                table: "items_purchase",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items_info",
                table: "items_info",
                columns: new[] { "Expiration_Date", "Item_Id" });

            migrationBuilder.CreateTable(
                name: "items_sale",
                columns: table => new
                {
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Sale_Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_No = table.Column<int>(type: "int", nullable: false),
                    Item_Discount = table.Column<float>(type: "real", nullable: false),
                    Item_Price = table.Column<float>(type: "real", nullable: false),
                    Item_Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items_sale", x => x.Sale_Item_Id);
                    table.ForeignKey(
                        name: "FK_items_sale_invoices_Invoice_No",
                        column: x => x.Invoice_No,
                        principalTable: "invoices",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_sale_items_info_Expiration_Date_Item_Id",
                        columns: x => new { x.Expiration_Date, x.Item_Id },
                        principalTable: "items_info",
                        principalColumns: new[] { "Expiration_Date", "Item_Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Expiration_Date_Item_Id",
                table: "items_sale",
                columns: new[] { "Expiration_Date", "Item_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Invoice_No",
                table: "items_sale",
                column: "Invoice_No");

            migrationBuilder.AddForeignKey(
                name: "FK_items_info_items_Item_Id",
                table: "items_info",
                column: "Item_Id",
                principalTable: "items",
                principalColumn: "Item_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_purchase_delegates_Delegate_ID",
                table: "items_purchase",
                column: "Delegate_ID",
                principalTable: "delegates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_purchase_items_Item_ID",
                table: "items_purchase",
                column: "Item_ID",
                principalTable: "items",
                principalColumn: "Item_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
