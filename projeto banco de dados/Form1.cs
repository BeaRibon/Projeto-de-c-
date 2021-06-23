using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class Login : Form
    {
        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();

            string email, senha;

            email = textBox1.Text;
            senha = textBox2.Text;

            string sql = @"select * from tb_login where tb_login_email = @tb_login_email and tb_login_senha = @tb_login_senha";

            MySqlCommand executacmd = new MySqlCommand(sql, con);

            executacmd.Parameters.AddWithValue("@tb_login_email", email);
            executacmd.Parameters.AddWithValue("@tb_login_senha", senha);

            MySqlDataReader dr = executacmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Bem-vindo ao sistema!");

                // objeto  classe

                principal principal = new principal();
                this.Hide();
                principal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Dados inválidos");
            }
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            cadastrologin cadastrologin = new cadastrologin();
            this.Hide();
            cadastrologin.ShowDialog();
        }
    }
}
