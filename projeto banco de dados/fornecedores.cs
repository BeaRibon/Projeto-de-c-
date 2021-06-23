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
    public partial class fornecedores : Form
    {

        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public fornecedores()
        {
            InitializeComponent();
        }

        public void dtfor()
        {
            try
            {


                MySqlConnection con = new MySqlConnection(conexao);
                con.Open();

                string sql_select_fornecedores = "select * from tb_fornecedores";
                MySqlCommand executacmdMySql_select = new MySqlCommand(sql_select_fornecedores, con);
                executacmdMySql_select.ExecuteNonQuery();

                DataTable tabela_fornecedores = new DataTable();

                MySqlDataAdapter da_funcionario = new MySqlDataAdapter(executacmdMySql_select);
                da_funcionario.Fill(tabela_fornecedores);

                dataGridView1.DataSource = tabela_fornecedores;

                con.Close();



            }

            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro 8" + erro);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            principal principal = new principal();
            this.Hide();
            principal.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // alterar
            try
            {
                MySqlConnection con = new MySqlConnection(conexao);
                con.Open();

                string nome, email, endereço, complemento, bairro, cidade, estado;
                int cnpj, telefone, celular, cep, numero, id;

                /// string
                nome = textBox1.Text;
                email = textBox4.Text;
                endereço = textBox11.Text;
                complemento = textBox13.Text;
                bairro = textBox14.Text;
                cidade = textBox16.Text;
                estado = textBox15.Text;

                /// int 

                cnpj = int.Parse(textBox2.Text);
                telefone = int.Parse(textBox8.Text);
                celular = int.Parse(textBox9.Text);
                cep = int.Parse(textBox10.Text);
                numero = int.Parse(textBox12.Text);
                id = int.Parse(textBox17.Text);


                string sql_update = @"update tb_fornecedores set
                                                              tb_fornecedores_nome = @fornecedores_nome,
                                                              tb_fornecedores_cnpj = @fornecedores_cnpj,
                                                              tb_fornecedores_email = @fornecedores_email,
                                                              tb_fornecedores_telefone = @fornecedores_telefone,
                                                              tb_fornecedores_celular = @fornecedores_celular,
                                                              tb_fornecedores_cep = @fornecedores_cep,
                                                              tb_fornecedores_endereço =  @fornecedores_endereço,
                                                              tb_fornecedores_numero = @fornecedores_numero,
                                                              tb_fornecedores_complemento = @fornecedores_complemento,
                                                              tb_fornecedores_bairro = @fornecedores_bairro,
                                                              tb_fornecedores_cidade = @fornecedores_cidade,
                                                              tb_fornecedores_estado = @fornecedores_estado
                                                               where tb_fornecedores_id = @fornecedores_id";

                MySqlCommand executaMySql_update = new MySqlCommand(sql_update, con);

                executaMySql_update.Parameters.AddWithValue("@fornecedores_nome", nome);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_cnpj", cnpj);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_email", email);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_telefone", telefone);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_celular", celular);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_cep", cep);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_endereço", endereço);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_numero", numero);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_complemento", complemento);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_bairro", bairro);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_cidade", cidade);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_estado", estado);
                executaMySql_update.Parameters.AddWithValue("@fornecedores_id", id);

                executaMySql_update.ExecuteNonQuery();

                con.Close();

                dtfor();

                MessageBox.Show("Fornecedor alterado");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro alterar" +
                    "" + erro);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // excluir 
            DialogResult dr = MessageBox.Show("Deseja realmente excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(conexao);
                    con.Open();
                    int id = int.Parse(textBox17.Text);
                    string sql_delete_fornecedores = @"delete from tb_fornecedores where tb_fornecedores_id = @id";
                    MySqlCommand executacmdMy_Sql_delete = new MySqlCommand(sql_delete_fornecedores, con);
                    executacmdMy_Sql_delete.Parameters.AddWithValue("@id", id);


                    executacmdMy_Sql_delete.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("fornecedor excluído");

                    dtfor();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Deu o erro 4" + erro);
                }


            }
            else
            {
                MessageBox.Show("O fornecedor não foi excluído");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conexao);
                con.Open();

                string nome, email, endereço, complemento, bairro, cidade, estado;
                int cnpj, telefone, celular, cep, numero;

                /// string
                nome = textBox1.Text;
                email = textBox4.Text;
                endereço = textBox11.Text;
                complemento = textBox13.Text;
                bairro = textBox14.Text;
                cidade = textBox16.Text;
                estado = textBox15.Text;

                /// int 

                cnpj = int.Parse(textBox2.Text);
                telefone = int.Parse(textBox8.Text);
                celular = int.Parse(textBox9.Text);
                cep = int.Parse(textBox10.Text);
                numero = int.Parse(textBox12.Text);


                string sql_insert = @"insert into tb_fornecedores(
                                                              tb_fornecedores_nome, 
                                                              tb_fornecedores_cnpj,
                                                              tb_fornecedores_email,
                                                              tb_fornecedores_telefone,
                                                              tb_fornecedores_celular,
                                                              tb_fornecedores_cep,
                                                              tb_fornecedores_endereço,
                                                              tb_fornecedores_numero,
                                                              tb_fornecedores_complemento,
                                                              tb_fornecedores_bairro, 
                                                              tb_fornecedores_cidade,
                                                              tb_fornecedores_estado)
                                                              values(
                                                              @fornecedores_nome, 
                                                              @fornecedores_cnpj,
                                                              @fornecedores_email, 
                                                              @fornecedores_telefone,
                                                              @fornecedores_celular,
                                                              @fornecedores_cep,
                                                              @fornecedores_endereço,
                                                              @fornecedores_numero,
                                                              @fornecedores_complemento,
                                                              @fornecedores_bairro, 
                                                              @fornecedores_cidade,
                                                              @fornecedores_estado)";

                MySqlCommand executaMySql_Insert = new MySqlCommand(sql_insert, con);

                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_nome", nome);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_cnpj", cnpj);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_email", email);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_telefone", telefone);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_celular", celular);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_cep", cep);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_endereço", endereço);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_numero", numero);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_complemento", complemento);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_bairro", bairro);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_cidade", cidade);
                executaMySql_Insert.Parameters.AddWithValue("@fornecedores_estado", estado);

                executaMySql_Insert.ExecuteNonQuery();

                con.Close();

                dtfor();

                MessageBox.Show("Cliente cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro 2 " + erro);
            }
        }

        private void fornecedores_Load(object sender, EventArgs e)
        {
            dtfor();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox17.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox16.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }
    }
}
