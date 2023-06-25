using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_de_pedidos.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInittial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(21,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensDePedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensDePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensDePedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Categoria = table.Column<byte>(type: "tinyint", nullable: false),
                    ItensDePedidoModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_ItensDePedido_ItensDePedidoModelId",
                        column: x => x.ItensDePedidoModelId,
                        principalTable: "ItensDePedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensDePedido_PedidoId",
                table: "ItensDePedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ItensDePedidoModelId",
                table: "Produtos",
                column: "ItensDePedidoModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ItensDePedido");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
