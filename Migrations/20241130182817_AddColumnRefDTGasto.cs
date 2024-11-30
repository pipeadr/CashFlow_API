using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlow_API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRefDTGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Gastos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_Referencia",
                table: "Gastos",
                column: "Referencia",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gastos_Referencia",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Gastos");
        }
    }
}
