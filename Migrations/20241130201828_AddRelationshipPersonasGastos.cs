using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlow_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipPersonasGastos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gastos_Referencia",
                table: "Gastos");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonaId",
                table: "Gastos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_PersonaId",
                table: "Gastos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_Referencia_PersonaId",
                table: "Gastos",
                columns: new[] { "Referencia", "PersonaId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Personas_PersonaId",
                table: "Gastos",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Personas_PersonaId",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_PersonaId",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_Referencia_PersonaId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Gastos");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_Referencia",
                table: "Gastos",
                column: "Referencia",
                unique: true);
        }
    }
}
