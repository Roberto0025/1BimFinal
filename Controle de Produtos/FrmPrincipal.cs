using System.Windows.Forms;

namespace Controle_de_Produtos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProduto_Click(object sender, System.EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto();
            frmProduto.ShowDialog();
        }

        private void btnEntrada_Click(object sender, System.EventArgs e)
        {
            FrmEntrada frmEntrada = new FrmEntrada();
            frmEntrada.ShowDialog();
        }

        private void btnSaida_Click(object sender, System.EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida();
            frmSaida.ShowDialog();
        }

        private void btnUsuario_Click(object sender, System.EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.ShowDialog();
        }
    }
}
