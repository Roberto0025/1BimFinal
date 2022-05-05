using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Produtos
{
    [Table("entrada", Schema = "public")]
    public class DtoEntrada
    {
        [Key]
        public int id { get; set; }
        public int idproduto { get; set; }
        public decimal? qtdeproduto { get; set; }
        public decimal? vlrcustoproduto { get; set; }
        public decimal? vlrtotalproduto { get; set; }
        public DateTime? dtcompra { get; set; }


    }
}
