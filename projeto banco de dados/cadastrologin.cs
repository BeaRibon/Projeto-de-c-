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
    public partial class cadastrologin : Form
    {

        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public cadastrologin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection con = new MySqlConnection(conexao);
                con.Open();

                string nome, email;
                int senha;

                nome = textBox1.Text;
                email = textBox2.Text;

                senha = int.Parse(textBox3.Text);

                string sql_insert = @"insert into tb_login(tb_login_nome, tb_login_email, tb_login_senha)
                                                         values(@login_nome, @login_email, @login_senha)";


                MySqlCommand executaMySql_Insert = new MySqlCommand(sql_insert, con);

                executaMySql_Insert.Parameters.AddWithValue("@login_nome", nome);
                executaMySql_Insert.Parameters.AddWithValue("@login_email", email);
                executaMySql_Insert.Parameters.AddWithValue("@login_senha", senha);

                executaMySql_Insert.ExecuteNonQuery();

                con.Close();
                
                MessageBox.Show("Você foi cadastrado com sucesso!");

                Login login = new Login();
                this.Hide();
                login.ShowDialog();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro" + erro);
            }
        }
    }
}
