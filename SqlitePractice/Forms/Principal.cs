using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlitePractice
{
    public partial class Principal : Form
    {
        BD.Modelo m = new BD.Modelo();
        BD.Dal dal = new BD.Dal();
        Boolean retorno = false;

        public Principal()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            m.nome = txtNome.Text;
            m.cpf = txtCpf.Text;
            m.rua = txtRua.Text;
            m.num = txtNum.Text;
            m.bairro = txtBairro.Text;
            m.cidade = txtCidade.Text;

            retorno = dal.insert(m);

            if (retorno)
            {
                MessageBox.Show("Inserido com Sucesso!");
            }
            else {
                MessageBox.Show("Ocorreu um erro ao inserir o Registro");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.Tabela tab = new Forms.Tabela();
            tab.ShowDialog();
        }
    }
}
