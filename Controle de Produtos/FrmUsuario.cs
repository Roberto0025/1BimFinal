using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controle_de_Produtos
{
    public partial class FrmUsuario : Controle_de_Produtos.FrmBase
    {
        public FrmUsuario()
        {
            InitializeComponent();
            carregarGrid();
        }
        private void carregarGrid()
        {
            Model model = new Model();
            List<DtoUsuario2> dtoUsuarios = model.GetUsuarios();
            dataGridView1.DataSource = dtoUsuarios;
            desahabilitaText();
        }
        public void habilitaText()
        {
            textLogin.Enabled = true;
            textName.Enabled = true;
            textSenha.Enabled = true;
        }
        public void desahabilitaText()
        {
            textLogin.Enabled = false;
            textName.Enabled = false;
            textSenha.Enabled = false;
        }
        private void btnIncuir_Click(object sender, EventArgs e)
        {
            habilitaText();
            LimparCampos();
            textName.Focus();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            DtoUsuario u = new DtoUsuario();
            if(textName.Text.Trim() == string.Empty ||textSenha.Text.Trim() == string.Empty || textLogin.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos não podem ser em branco!!");
                textName.Focus();
                return;
            }
            else
            {
                u.nome = textName.Text;
                u.login = textLogin.Text;
                u.senha = textSenha.Text;
            }
            if(textID.Text == String.Empty)
            {
                model.SetUsuario(u);

            }
            else
            {
                u.id = int.Parse(textID.Text);
                model.AlterarUsuario(u);
            }
         
            carregarGrid();
            LimparCampos();
        }
        private void LimparCampos()
        {
            textID.Text = string.Empty;
            textName.Text = string.Empty;
            textSenha.Text = string.Empty;
            textLogin.Text = string.Empty;
        }
        private void dataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Model model = new Model();
            DtoUsuario user = model.GetUsuario(id);

            textID.Text = user.id.ToString();
            textName.Text = user.nome.ToString();
            textLogin.Text = user.login.ToString();
            textSenha.Text = user.senha.ToString();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitaText();
            textName.Focus();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Model model = new Model();
                model.delUsuario(int.Parse(textID.Text));
                textID.Text = String.Empty;
                carregarGrid();
                LimparCampos();
            }
            catch (Exception)
            {

                MessageBox.Show("Selecione um usuario com 2 click do mouse!");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            desahabilitaText();
        }
    }
}
