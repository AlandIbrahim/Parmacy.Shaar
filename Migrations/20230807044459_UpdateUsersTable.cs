using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "users",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Employee_Id",
                table: "items_sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Location_in_Storage",
                table: "items_info",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_in_Pharmacy",
                table: "items_info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_sale_Employee_Id",
                table: "items_sale",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_items_sale_users_Employee_Id",
                table: "items_sale",
                column: "Employee_Id",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_sale_users_Employee_Id",
                table: "items_sale");

            migrationBuilder.DropIndex(
                name: "IX_items_sale_Employee_Id",
                table: "items_sale");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Employee_Id",
                table: "items_sale");

            migrationBuilder.AlterColumn<string>(
                name: "Location_in_Storage",
                table: "items_info",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Location_in_Pharmacy",
                table: "items_info",
                nullable: false);
        }
    }
}
