using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_caixa_igreja.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCulto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCulto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOferta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membros_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdAdultos = table.Column<int>(type: "int", nullable: false),
                    QtdCriancas = table.Column<int>(type: "int", nullable: false),
                    totalOferta = table.Column<double>(type: "float", nullable: false),
                    IdTipoCulto = table.Column<int>(type: "int", nullable: false),
                    IdTipoOferta = table.Column<int>(type: "int", nullable: false),
                    IdMembroMinistrante = table.Column<int>(type: "int", nullable: false),
                    IdMembroOfertante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofertas_Membros_IdMembroMinistrante",
                        column: x => x.IdMembroMinistrante,
                        principalTable: "Membros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ofertas_Membros_IdMembroOfertante",
                        column: x => x.IdMembroOfertante,
                        principalTable: "Membros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ofertas_TipoCulto_IdTipoCulto",
                        column: x => x.IdTipoCulto,
                        principalTable: "TipoCulto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ofertas_TipoOferta_IdTipoOferta",
                        column: x => x.IdTipoOferta,
                        principalTable: "TipoOferta",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Pessoa com ficha de membro frequente aos cultos", "Membro" },
                    { 2, "Pessoa Membra com responsabilidades na obra", "Obreiro" },
                    { 3, "Pessoa auxiliadora do ministerio diaconal", "Diacono" },
                    { 4, "Pessoa Obreita integrante do ministerio de louvor", "Levita" }
                });

            migrationBuilder.InsertData(
                table: "TipoCulto",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Último domingo de cada mês. Ceia do Senhor para batizados nas águas.", "Santa Ceia" },
                    { 2, "No 4º domingo do mês quando há 5 domingos no mês.", "Centésima ovelha" },
                    { 3, "3º Domingo do mês. Ofertas destinadas para missão não ficam no caixa da igreja", "Missões" },
                    { 4, "2º Domingo. Geralmente nesse dia são devolvidos Dizimos e primicias", "Properidade" },
                    { 5, "1º Domingo do mês. Culto para batismo e renovo do espirito santo", "Poder" },
                    { 6, "Todos os dias de semana. Seg a Sex", "Graça" }
                });

            migrationBuilder.InsertData(
                table: "TipoOferta",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Dinheiro em especie no culto.", "Cédulas C." },
                    { 2, "Dinheiro em especia fora do culto", "Cédulas F." },
                    { 3, "Transferencia de conta. (TED, DOC, PIX)", "Transferência" },
                    { 4, "Cheques fora do culto", "Cheques" },
                    { 5, "Feito com cartão crédito/debito", "Cartão" }
                });

            migrationBuilder.InsertData(
                table: "Membros",
                columns: new[] { "Id", "CargoId", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1995, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodolfo Jesus Silva" },
                    { 2, 2, new DateTime(1993, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kelly Cristina Martins" },
                    { 3, 3, new DateTime(2006, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustavo de Jesus Silva" },
                    { 4, 4, new DateTime(2000, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Casy Martins da Silva" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membros_CargoId",
                table: "Membros",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdMembroMinistrante",
                table: "Ofertas",
                column: "IdMembroMinistrante");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdMembroOfertante",
                table: "Ofertas",
                column: "IdMembroOfertante");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdTipoCulto",
                table: "Ofertas",
                column: "IdTipoCulto");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdTipoOferta",
                table: "Ofertas",
                column: "IdTipoOferta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "TipoCulto");

            migrationBuilder.DropTable(
                name: "TipoOferta");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
