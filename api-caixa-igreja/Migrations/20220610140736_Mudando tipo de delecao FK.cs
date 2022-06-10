using Microsoft.EntityFrameworkCore.Migrations;

namespace api_caixa_igreja.Migrations
{
    public partial class MudandotipodedelecaoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Cargos_CargoId",
                table: "Membros");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Cargos_CargoId",
                table: "Membros",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Cargos_CargoId",
                table: "Membros");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Cargos_CargoId",
                table: "Membros",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
