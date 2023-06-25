using Controle_de_pedidos.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_pedidos.Models
{
    public class ProdutosModel
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Nome { get; set;}

        [Column(TypeName = "tinyint")]
        public Categorias Categoria { get; set;}
    }
}
