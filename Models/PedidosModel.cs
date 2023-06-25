using Controle_de_pedidos.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Controle_de_pedidos.Models
{
    public class PedidosModel
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Identificador { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(21,2)")]
        public decimal? ValorTotal { get; set; }
    }
}
