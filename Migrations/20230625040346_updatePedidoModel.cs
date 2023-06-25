using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_de_pedidos.Migrations
{
    /// <inheritdoc />
    public partial class updatePedidoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "decimal(21,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(21,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "decimal(21,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(21,2)",
                oldNullable: true);
        }
    }
}
