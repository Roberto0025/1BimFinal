using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Controle_de_Produtos
{
    public partial class FrmProduto : Controle_de_Produtos.FrmBase
    {
        public FrmProduto()
        {
            InitializeComponent();
            CarregarGrid();
            DesahabilitaText();
        }/*
        private void btnAcessar_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            DtoProduto p = new DtoProduto();
            p.nome = textNome.Text;
            p.valorcompra = decimal.Parse(textValorCompra.Text);
            p.valorvenda = decimal.Parse(textValorVenda.Text);
            p.quantidade = decimal.Parse(textQuantidade.Text);
            p.unidade = textUnidade.Text;

            model.SetProduto(p);
        }*/
        private void btnIncuir_Click(object sender, EventArgs e)
        {
            HabilitarText();
            LimparCampos();
            textNome.Focus();
        }
        private void LimparCampos()
        {
            textId.Text = string.Empty;
            textNome.Text = string.Empty;
            textValorCompra.Text = string.Empty;
            textValorVenda.Text = string.Empty;
            textQuantidade.Text = string.Empty;
            textUnidade.Text = string.Empty;
        }
        private void HabilitarText()
        {
            textNome.Enabled = true;
            textValorCompra.Enabled = true;
            textValorVenda.Enabled = true;
            textQuantidade.Enabled = true;
            textUnidade.Enabled = true;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            DtoProduto p = new DtoProduto();
            if (textNome.Text.Trim() == string.Empty || textValorCompra.Text.Trim() == string.Empty || 
                textValorVenda.Text.Trim() == string.Empty || textQuantidade.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos não podem ser em branco!!");
                textNome.Focus();
                return;
            }
            else
            {
                p.nome = textNome.Text;
                p.valorvenda = decimal.Parse(textValorVenda.Text);
                p.valorcompra = decimal.Parse(textValorCompra.Text);
                p.quantidade = decimal.Parse(textQuantidade.Text);
                p.unidade = textUnidade.Text;
            }
            if (textId.Text == String.Empty)
            {
                model.SetProduto(p);

            }
            else
            {
                p.id = int.Parse(textId.Text);
                model.AlterarProduto(p);
            }

            CarregarGrid();
            LimparCampos();
        }
        private void CarregarGrid()
        {
            Model model = new Model();
            List<DtoProduto2> dtoProdutos = model.GetProdutos();
            dataGridView1.DataSource = dtoProdutos;
            DesahabilitaText();
        }
        private void DesahabilitaText()
        {
            textId.Enabled = false;
            textNome.Enabled = false;
            textValorCompra.Enabled = false;
            textValorVenda.Enabled = false;
            textQuantidade.Enabled = false;
            textUnidade.Enabled = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarText();
            textNome.Focus();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Model model = new Model();
                model.delProduto(int.Parse(textId.Text));
                textId.Text = String.Empty;
                CarregarGrid();
                LimparCampos();
            }
            catch (Exception)
            {

                MessageBox.Show("Selecione um produto com 2 click do mouse!");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesahabilitaText();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Model model = new Model();
            DtoProduto prod = model.GetProduto(id);

            textId.Text = prod.id.ToString();
            textNome.Text = prod.nome.ToString();
            textValorCompra.Text = prod.valorcompra.ToString();
            textValorVenda.Text = prod.valorvenda.ToString();
            textQuantidade.Text = prod.quantidade.ToString();
            textUnidade.Text = prod.unidade.ToString();
        }
    }
}
