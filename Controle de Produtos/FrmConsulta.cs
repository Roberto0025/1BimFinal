using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Produtos
{
    public partial class FrmConsulta : Form
    {
        public int idProduto = 0;
        public FrmConsulta()
        {
            InitializeComponent();
            Model m = new Model();
            List<DtoProduto2> list = m.ListProdutosNome(textBox1.Text);
            dataGridView1.DataSource = list;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Model m = new Model();
            List<DtoProduto2> list = m.ListProdutosNome(textBox1.Text);
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                idProduto = (Int32)dataGridView1.CurrentRow.Cells[0].Value;
                Close();
            }
        }
    }
}
