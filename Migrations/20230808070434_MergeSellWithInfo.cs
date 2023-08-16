using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class MergeSellWithInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_sale_items_sell_Sale_Id",
                table: "items_sale");

            migrationBuilder.DropTable(
                name: "items_sell");

            migrationBuilder.DropIndex(
                name: "IX_items_sale_Sale_Id",
                table: "items_sale");

            migrationBuilder.RenameColumn(
                name: "Sale_Id",
                table: "items_sale",
                newName: "Item_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration_Date",
                table: "items_sale",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Item_Id",
                table: "items_sale",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Item_Id",
                table: "items_info",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration_Date",
                table: "items_info",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Expiration_Date_Item_Id",
                table: "items_sale",
                columns: new[] { "Expiration_Date", "Item_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_items_sale_items_info_Expiration_Date_Item_Id",
                table: "items_sale",
                columns: new[] { "Expiration_Date", "Item_Id" },
                principalTable: "items_info",
                principalColumns: new[] { "Expiration_Date", "Item_Id" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_sale_items_info_Expiration_Date_Item_Id",
                table: "items_sale");

            migrationBuilder.DropIndex(
                name: "IX_items_sale_Expiration_Date_Item_Id",
                table: "items_sale");

            migrationBuilder.RenameColumn(
                name: "Item_Id",
                table: "items_sale",
                newName: "Sale_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration_Date",
                table: "items_sale",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Sale_Id",
                table: "items_sale",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Item_Id",
                table: "items_info",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration_Date",
                table: "items_info",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateTable(
                name: "items_sell",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_ID = table.Column<int>(type: "int", nullable: false),
                    Purchase_Price = table.Column<float>(type: "real", nullable: false),
                    Sale_Price = table.Column<float>(type: "real", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Sale_Id",
                table: "items_sale",
                column: "Sale_Id");

            migrationBuilder.CreateIndex(
                name: "IX_items_sell_Item_ID",
                table: "items_sell",
                column: "Item_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_sale_items_sell_Sale_Id",
                table: "items_sale",
                column: "Sale_Id",
                principalTable: "items_sell",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
