using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaoInvestimentosInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VersaoInicial : Migration
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
                    TipoAtivo = table.Column<string>(type: "VARCHAR(100)", nullable: false),
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
                    TipoTransacao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
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
                    { 1, "ATV01", "Nome Ativo 1", "Acao" },
                    { 2, "ATV02", "Nome Ativo 2", "Titulo" },
                    { 3, "ATV03", "Nome Ativo 3", "Criptomoeda" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, "rm352321@fiap.com.br", "Demetrios Pandelis Arghirachis", "1q2w3e4r@#" },
                    { 2, "usuario@teste.io", "usuario teste", "1q2w3e4r@#" }
                });

            migrationBuilder.InsertData(
                table: "Portfolio",
                columns: new[] { "Id", "Descricao", "Nome", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Descricao Portfolio 1", "Nome Portfolio 1", 1 },
                    { 2, "Descricao Portfolio 2", "Nome Portfolio 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Transacao",
                columns: new[] { "Id", "AtivoId", "DataTransacao", "PortfolioId", "Preco", "Quantidade", "TipoTransacao" },
                values: new object[,]
                {
                    { 1, 1, "2024-06-05 22:18:32.4447519", 1, "150", "10", "TipoTransacao 1" },
                    { 2, 2, "2024-06-05 22:18:32.4447543", 1, "300", "20", "TipoTransacao 2" },
                    { 3, 1, "2024-06-05 22:18:32.4447547", 2, "600", "50", "TipoTransacao 3" },
                    { 4, 2, "2024-06-05 22:18:32.4447551", 2, "900", "90", "TipoTransacao 4" }
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
