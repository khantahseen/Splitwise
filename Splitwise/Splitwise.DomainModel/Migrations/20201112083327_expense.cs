using Microsoft.EntityFrameworkCore.Migrations;

namespace Splitwise.DomainModel.Migrations
{
    public partial class expense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Settlements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_ExpenseId",
                table: "Settlements",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Expenses_ExpenseId",
                table: "Settlements",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Expenses_ExpenseId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_ExpenseId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Settlements");
        }
    }
}
