using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaoInvestimentosInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Versao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAtivo = table.Column<int>(type: "INT", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Codigo = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "INT", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "INT", nullable: false),
                    AtivoId = table.Column<int>(type: "INT", nullable: false),
                    TipoTransacao = table.Column<int>(type: "INT", nullable: false),
                    Quantidade = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Preco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DataTransacao = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Ativo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacao_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ativo",
                columns: new[] { "Id", "Codigo", "Nome", "TipoAtivo" },
                values: new object[,]
                {
                    { 1, "NAA001", "Nome Ativo Acao 001", 1 },
                    { 2, "NAT001", "Nome Ativo Titulo 001", 2 },
                    { 3, "NAC001", "Nome Ativo Criptomoeda 001", 3 },
                    { 4, "NAT002", "Nome Ativo Titulo 002", 2 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, "rm352321@fiap.com.br", "Demetrios Pandelis Arghirachis", "1q2w3e4r@#" },
                    { 2, "rm351017@fiap.com.br", "Erick Felipe Vieira da Silva", "1q2w3e4r@#" },
                    { 3, "rm352116@fiap.com.br", "MARINA SANT'ANA MIRANDA DE OLIVEIRA", "1q2w3e4r@#" },
                    { 4, "rm352127@fiap.com.br", "Pamela Suellen Souza Caffa", "1q2w3e4r@#" }
                });

            migrationBuilder.InsertData(
                table: "Portfolio",
                columns: new[] { "Id", "Descricao", "Nome", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Descricao Portfolio Demetrios", "Portfolio Demetrios", 1 },
                    { 2, "Descricao Portfolio Erick", "Portfolio Erick", 2 },
                    { 3, "Descricao Portfolio MARINA", "Portfolio MARINA", 3 },
                    { 4, "Descricao Portfolio Pamela", "Portfolio Pamela", 4 }
                });

            migrationBuilder.InsertData(
                table: "Transacao",
                columns: new[] { "Id", "AtivoId", "DataTransacao", "PortfolioId", "Preco", "Quantidade", "TipoTransacao" },
                values: new object[,]
                {
                    { 1, 1, "2024-06-10 11:02:30.0872848", 1, "150", "10", 1 },
                    { 2, 2, "2024-06-10 11:02:30.0872867", 1, "150", "10", 2 },
                    { 3, 3, "2024-06-10 11:02:30.0872871", 1, "150", "10", 1 },
                    { 4, 4, "2024-06-10 11:02:30.0872874", 1, "150", "10", 2 },
                    { 5, 1, "2024-06-10 11:02:30.0872877", 2, "150", "10", 1 },
                    { 6, 2, "2024-06-10 11:02:30.087288", 2, "150", "10", 2 },
                    { 7, 3, "2024-06-10 11:02:30.0872882", 2, "150", "10", 1 },
                    { 8, 4, "2024-06-10 11:02:30.0872885", 2, "150", "10", 2 },
                    { 9, 1, "2024-06-10 11:02:30.087289", 3, "150", "10", 1 },
                    { 10, 2, "2024-06-10 11:02:30.0872893", 3, "150", "10", 2 },
                    { 11, 3, "2024-06-10 11:02:30.0872896", 3, "150", "10", 1 },
                    { 12, 4, "2024-06-10 11:02:30.0872898", 3, "150", "10", 2 },
                    { 13, 1, "2024-06-10 11:02:30.08729", 4, "150", "10", 1 },
                    { 14, 2, "2024-06-10 11:02:30.0872902", 4, "150", "10", 2 },
                    { 15, 3, "2024-06-10 11:02:30.0872904", 4, "150", "10", 1 },
                    { 16, 4, "2024-06-10 11:02:30.0872907", 4, "150", "10", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UsuarioId",
                table: "Portfolio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_AtivoId",
                table: "Transacao",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_PortfolioId",
                table: "Transacao",
                column: "PortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Ativo");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
