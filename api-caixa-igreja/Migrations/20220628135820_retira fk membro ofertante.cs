    using Microsoft.EntityFrameworkCore.Migrations;

namespace api_caixa_igreja.Migrations
{
    public partial class retirafkmembroofertante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Membros_IdMembroOfertante",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_IdMembroOfertante",
                table: "Ofertas");

            migrationBuilder.AddColumn<int>(
                name: "MembroOfertanteId",
                table: "Ofertas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_MembroOfertanteId",
                table: "Ofertas",
                column: "MembroOfertanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Membros_MembroOfertanteId",
                table: "Ofertas",
                column: "MembroOfertanteId",
                principalTable: "Membros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Membros_MembroOfertanteId",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_MembroOfertanteId",
                table: "Ofertas");

            migrationBuilder.DropColumn(
                name: "MembroOfertanteId",
                table: "Ofertas");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdMembroOfertante",
                table: "Ofertas",
                column: "IdMembroOfertante");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Membros_IdMembroOfertante",
                table: "Ofertas",
                column: "IdMembroOfertante",
                principalTable: "Membros",
                principalColumn: "Id");
        }
    }
}
