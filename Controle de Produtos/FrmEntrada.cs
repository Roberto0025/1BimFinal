using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Controle_de_Produtos
{
    public partial class FrmEntrada : Controle_de_Produtos.FrmBase
    {
        public FrmEntrada()
        {
            InitializeComponent();
            DesahabilitaText();
            Model model = new Model();
            List<DtoProduto2> dtoProdutos = model.GetProdutos();
            dataGridView1.DataSource = dtoProdutos;
        }
        private void HabilitaTex()
        {
            txtIdProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtVlrUnitario.Enabled = true;
            txtVlrTotal.Enabled = false;
            txtIdProduto.Focus();
        }
        private void DesahabilitaText()
        {
            txtIdProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtVlrUnitario.Enabled = false;
            txtVlrTotal.Enabled = false;
        }
        private void btnIncuir_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            List<DtoProduto2> dtoProdutos = model.GetProdutos();
            dataGridView1.DataSource = dtoProdutos;
            HabilitaTex();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model model = new Model();
                DtoEntrada entrada = new DtoEntrada();
                entrada.idproduto = int.Parse(txtIdProduto.Text);
                entrada.qtdeproduto = decimal.Parse(txtQuantidade.Text);
                entrada.vlrcustoproduto = decimal.Parse(txtVlrUnitario.Text);
                entrada.vlrtotalproduto = decimal.Parse(txtVlrTotal.Text);
                entrada.dtcompra = DateTime.Now;

                model.SetEntradaProduto(entrada);
                DesahabilitaText();
            }
            catch (Exception)
            {

                MessageBox.Show("Selecione um item!");
            }
            finally
            {
                Model model = new Model();
                List<DtoProduto2> dtoProdutos = model.GetProdutos();
                dataGridView1.DataSource = dtoProdutos;
                LimparCapos();
            }
        }

        private void LimparCapos()
        {
            txtId.Text = String.Empty;
            txtIdProduto.Text = String.Empty;
            txtQuantidade.Text = String.Empty;
            txtVlrUnitario.Text = String.Empty;
            txtVlrTotal.Text = String.Empty;
            txtQuantidade.Text = String.Empty;
        }

        private void CalcularTotalDoItem(decimal v)
        {
            Model model = new Model();
            List<DtoProduto2> dtoProdutos = model.GetProdutos();
            dataGridView1.DataSource = dtoProdutos;
            decimal vlrUni = decimal.Parse(txtVlrUnitario.Text);
            decimal vlrTotal = v * vlrUni;
            txtVlrTotal.Text = vlrTotal.ToString();
        }
        private void txtIdProduto_Leave(object sender, EventArgs e)
        {
            try
            {
                Model model = new Model();
                if (txtIdProduto.Text != string.Empty)
                {
                    DtoProduto prod = model.GetProdutoId(int.Parse(txtIdProduto.Text));
                    txtDescProduto.Text = prod.nome.ToString();
                    txtVlrUnitario.Text = prod.valorcompra.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao buscar o produto!");
                LimparCapos();
                HabilitaTex();
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            FrmConsulta c = new FrmConsulta();
            c.ShowDialog();
            if (c.idProduto != 0)
            {
                txtIdProduto.Text = c.idProduto.ToString();
                txtDescProduto.Focus();
            }
            Model model = new Model();
            List<DtoProduto2> dtoProdutos = model.GetProdutos();
            dataGridView1.DataSource = dtoProdutos;
        }
      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCapos();
            DesahabilitaText();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            calcular();
        }

        private void calcular()
        {
            if (txtVlrUnitario == null)
                return;
            try
            {
                CalcularTotalDoItem(int.Parse(txtQuantidade.Text));
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao cacular valor unitario!");
            }
        }

        private void txtVlrUnitario_Leave(object sender, EventArgs e)
        {
            calcular();
        }

        private void btnPesquisa_Leave(object sender, EventArgs e)
        {
            Model model = new Model();
            if (txtIdProduto.Text != string.Empty)
            {
                DtoProduto prod = model.GetProdutoId(int.Parse(txtIdProduto.Text));
                txtDescProduto.Text = prod.nome.ToString();
                txtVlrUnitario.Text = prod.valorcompra.ToString();
            }
        }
    }
}
