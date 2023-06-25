using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Controle_de_pedidos.Models
{
    public class ItensDePedidoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set;}
        [JsonIgnore]
        public PedidosModel? Pedido { get; set;}
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public ProdutosModel? Produto { get; set; }
        public int Quantidade { get; set;}

        [Column(TypeName = "decimal(9,2)")]
        public decimal Valor { get; set;}
    }
}
