using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto3Camada
{
    public partial class TelaFornecedor : Form
    {
        public TelaFornecedor()
        {
            InitializeComponent();
        }

        Fornecedor forn;

        private void CarregaTabela()
        {
            forn = new Fornecedor();
            dgvDados.DataSource = forn.Pesquisar();
        }
        private void TelaFornecedor_Load(object sender, EventArgs e)
        {
            CarregaTabela();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
         // forn.Id = int.Parse(txtID.Text);
            forn.Cnpj = mtxtCnpj.Text;
            forn.Email = txtEmail.Text;
            forn.Telefone = mtxtTelefone.Text;
            forn.Razao = txtRazaosocial.Text;
            MessageBox.Show(forn.Gravar() ? "Salvo com sucesso!" : "Não foi possível Salvar!");
            CarregaTabela();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = int.Parse(txtID.Text);
            forn.Cnpj = mtxtCnpj.Text;
            forn.Email = txtEmail.Text;
            forn.Telefone = mtxtTelefone.Text;
            forn.Razao = txtRazaosocial.Text;
            MessageBox.Show(forn.Atualizar() ? "Atualizado com sucesso!" : "Não foi possível atualizar!");
            CarregaTabela();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = int.Parse(txtID.Text);
            MessageBox.Show(forn.Excluir() ? "Excluído com sucesso!" : "Não foi possível excluir!");
            CarregaTabela();
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            forn.Id = Convert.ToInt32(dgvDados["id", e.RowIndex].Value);
            DataTable dt = forn.PesquisarId();
            txtID.Text = dt.Rows[0][forn.Id].ToString();
            mtxtCnpj.Text = dt.Rows[0][forn.Cnpj].ToString();
            txtEmail.Text = dt.Rows[0][forn.Email].ToString();
            txtRazaosocial.Text = dt.Rows[0][forn.Razao].ToString();
            mtxtTelefone.Text = dt.Rows[0][forn.Telefone].ToString();
        }
    }
}
