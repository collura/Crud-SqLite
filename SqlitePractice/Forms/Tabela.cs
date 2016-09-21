using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SqlitePractice.Forms
{



    public partial class Tabela : Form
    {
        SQLiteDataReader reader;
        Boolean retorno;
        public Tabela()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Tabela_Load(object sender, EventArgs e)
        {
            BD.Dal dal = new BD.Dal();
            reader = dal.select();

            while (reader.Read())
            {
                if (reader["id"].ToString() == String.Empty)
                {
                    MessageBox.Show("Vazio");
                    this.Close();
                }
                else
                {
                    grid.Rows.Add(reader["id"], reader["name"], reader["cpf"], reader["rua"], reader["num"], reader["bairro"], reader["cidade"]);
                }               
            }
            dal.conn.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //int id = grid.CurrentRow.Cells[0];
            BD.Dal dal = new BD.Dal();
            retorno =  dal.delete("1");
            if (retorno)
            {
                MessageBox.Show(id.ToString());
            }
            else {
                MessageBox.Show("Não foi");
            }
        }
    }
}
