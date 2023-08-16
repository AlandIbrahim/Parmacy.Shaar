using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeToPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Employee_ID",
                table: "items_Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_items_Purchase_Employee_ID",
                table: "items_Purchase",
                column: "Employee_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_Purchase_users_Employee_ID",
                table: "items_Purchase",
                column: "Employee_ID",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_Purchase_users_Employee_ID",
                table: "items_Purchase");

            migrationBuilder.DropIndex(
                name: "IX_items_Purchase_Employee_ID",
                table: "items_Purchase");

            migrationBuilder.DropColumn(
                name: "Employee_ID",
                table: "items_Purchase");
        }
    }
}
