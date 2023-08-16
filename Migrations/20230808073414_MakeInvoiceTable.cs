using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class MakeInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_sale_customers_Cu_Id",
                table: "items_sale");

            migrationBuilder.DropForeignKey(
                name: "FK_items_sale_users_Employee_Id",
                table: "items_sale");

            migrationBuilder.DropIndex(
                name: "IX_items_sale_Cu_Id",
                table: "items_sale");

            migrationBuilder.DropIndex(
                name: "IX_items_sale_Employee_Id",
                table: "items_sale");

            migrationBuilder.DropColumn(
                name: "Cu_Id",
                table: "items_sale");

            migrationBuilder.DropColumn(
                name: "Employee_Id",
                table: "items_sale");

            migrationBuilder.DropColumn(
                name: "Invoice_Date",
                table: "items_sale");

            migrationBuilder.CreateTable(
                name: "invoices",
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
                name: "IX_items_sale_Invoice_No",
                table: "items_sale",
                column: "Invoice_No");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_Cu_Id",
                table: "invoices",
                column: "Cu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_Employee_Id",
                table: "invoices",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_items_sale_invoices_Invoice_No",
                table: "items_sale",
                column: "Invoice_No",
                principalTable: "invoices",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_sale_invoices_Invoice_No",
                table: "items_sale");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_items_sale_Invoice_No",
                table: "items_sale");

            migrationBuilder.AddColumn<int>(
                name: "Cu_Id",
                table: "items_sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Employee_Id",
                table: "items_sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Invoice_Date",
                table: "items_sale",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Cu_Id",
                table: "items_sale",
                column: "Cu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Employee_Id",
                table: "items_sale",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_items_sale_customers_Cu_Id",
                table: "items_sale",
                column: "Cu_Id",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_sale_users_Employee_Id",
                table: "items_sale",
                column: "Employee_Id",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
