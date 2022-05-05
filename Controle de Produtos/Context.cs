using System.Data.Entity;

namespace Controle_de_Produtos
{
    public class Context : DbContext
    {
        public Context(): base("BD")
        {

        }
        public DbSet<DtoUsuario> usuario { get; set; }

        public DbSet<DtoProduto> produto { get; set; }

        public DbSet<DtoEntrada> entrada { get; set; }
    }
}
