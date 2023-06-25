using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_de_pedidos.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ItensDePedido_ItensDePedidoModelId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ItensDePedidoModelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ItensDePedidoModelId",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_ItensDePedido_ProdutoId",
                table: "ItensDePedido",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDePedido_Produtos_ProdutoId",
                table: "ItensDePedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensDePedido_Produtos_ProdutoId",
                table: "ItensDePedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensDePedido_ProdutoId",
                table: "ItensDePedido");

            migrationBuilder.AddColumn<int>(
                name: "ItensDePedidoModelId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ItensDePedidoModelId",
                table: "Produtos",
                column: "ItensDePedidoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ItensDePedido_ItensDePedidoModelId",
                table: "Produtos",
                column: "ItensDePedidoModelId",
                principalTable: "ItensDePedido",
                principalColumn: "Id");
        }
    }
}
