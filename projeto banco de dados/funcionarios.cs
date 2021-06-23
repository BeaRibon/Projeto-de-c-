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
    public partial class funcionarios : Form
    {

        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public funcionarios()
        {
            InitializeComponent();
        }

        public void dtfun()
        {
            try
            {


                MySqlConnection con = new MySqlConnection(conexao);
                con.Open();

                string sql_select_funcionario = "select * from tb_funcionarios";
                MySqlCommand executacmdMySql_select = new MySqlCommand(sql_select_funcionario, con);
                executacmdMySql_select.ExecuteNonQuery();

                DataTable tabela_funcionario = new DataTable();

                MySqlDataAdapter da_funcionario = new MySqlDataAdapter(executacmdMySql_select);
                da_funcionario.Fill(tabela_funcionario);

                dataGridView1.DataSource = tabela_funcionario;

                con.Close();



            }

            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro 2" + erro);

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

                string nome, email, senha, cargo, nivel_acesso, endereço, complemento, bairro, cidade, estado;
                int rg, cpf, telefone, celular, cep, numero, id;

                /// string
                nome = textBox1.Text;
                email = textBox4.Text;
                senha = textBox5.Text;
                cargo = textBox6.Text;
                nivel_acesso = textBox7.Text;
                endereço = textBox11.Text;
                complemento = textBox13.Text;
                bairro = textBox14.Text;
                cidade = textBox16.Text;
                estado = textBox15.Text;

                /// int 
                rg = int.Parse(textBox2.Text);
                cpf = int.Parse(textBox3.Text);
                telefone = int.Parse(textBox8.Text);
                celular = int.Parse(textBox9.Text);
                cep = int.Parse(textBox10.Text);
                numero = int.Parse(textBox12.Text);
                id = int.Parse(textBox17.Text);


                string sql_update = @"update tb_funcionarios set 
                                                              tb_funcionarios_nome =  @funcionarios_nome,
                                                              tb_funcionarios_rg = @funcionarios_rg,
                                                              tb_funcionarios_cpf = @funcionarios_cpf,
                                                              tb_funcionarios_email =  @funcionarios_email,
                                                              tb_funcionarios_senha = @funcionarios_senha, 
                                                              tb_funcionarios_cargo = @funcionarios_cargo,
                                                              tb_funcionarios_nivel_acesso = @funcionarios_nivel_acesso,
                                                              tb_funcionarios_telefone =  @funcionarios_telefone,
                                                              tb_funcionarios_celular = @funcionarios_celular,
                                                              tb_funcionarios_cep = @funcionarios_cep,
                                                              tb_funcionarios_endereço =  @funcionarios_endereço,
                                                              tb_funcionarios_numero = @funcionarios_numero,
                                                              tb_funcionarios_complemento = @funcionarios_complemento,
                                                              tb_funcionarios_bairro = @funcionarios_bairro,
                                                              tb_funcionarios_cidade = @funcionarios_cidade,
                                                              tb_funcionarios_estado = @funcionarios_estado
                                                               where tb_funcionarios_id = @funcionarios_id";

                MySqlCommand executaMySql_update = new MySqlCommand(sql_update, con);

                executaMySql_update.Parameters.AddWithValue("@funcionarios_nome", nome);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_rg", rg);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_cpf", cpf);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_email", email);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_senha", senha);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_cargo", cargo);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_nivel_acesso", nivel_acesso);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_telefone", telefone);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_celular", celular);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_cep", cep);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_endereço", endereço);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_numero", numero);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_complemento", complemento);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_bairro", bairro);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_cidade", cidade);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_estado", estado);
                executaMySql_update.Parameters.AddWithValue("@funcionarios_id", id);


                executaMySql_update.ExecuteNonQuery();

                con.Close();



                MessageBox.Show("funcionário alterado!");

                dtfun();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro alterar " + erro);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /// Excluir
            DialogResult dr = MessageBox.Show("Deseja realmente excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(conexao);
                    con.Open();
                    int id = int.Parse(textBox17.Text);
                    string sql_delete_funcionarios = @"delete from tb_funcionarios where tb_funcionarios_id = @id";
                    MySqlCommand executacmdMy_Sql_delete = new MySqlCommand(sql_delete_funcionarios, con);
                    executacmdMy_Sql_delete.Parameters.AddWithValue("@id", id);


                    executacmdMy_Sql_delete.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("funcionario excluído");

                    dtfun();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Deu o erro excluir" + erro);
                }


            }
            else
            {
                MessageBox.Show("O funcionario não foi excluído");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cadastrar

            try
            {
                MySqlConnection con = new MySqlConnection(conexao);
                con.Open();

                string nome, email, senha, cargo, nivel_acesso, endereço, complemento, bairro, cidade, estado;
                int rg, cpf, telefone, celular, cep, numero;

                /// string
                nome = textBox1.Text;
                email = textBox4.Text;
                senha = textBox5.Text;
                cargo = textBox6.Text;
                nivel_acesso = textBox7.Text;
                endereço = textBox11.Text;
                complemento = textBox13.Text;
                bairro = textBox14.Text;
                cidade = textBox16.Text;
                estado = textBox15.Text;

                /// int 
                rg = int.Parse(textBox2.Text);
                cpf = int.Parse(textBox3.Text);
                telefone = int.Parse(textBox8.Text);
                celular = int.Parse(textBox9.Text);
                cep = int.Parse(textBox10.Text);
                numero = int.Parse(textBox12.Text);


                string sql_insert = @"insert into tb_funcionarios(
                                                              tb_funcionarios_nome, 
                                                              tb_funcionarios_rg,
                                                              tb_funcionarios_cpf,
                                                              tb_funcionarios_email,
                                                              tb_funcionarios_senha,
                                                              tb_funcionarios_cargo, 
                                                              tb_funcionarios_nivel_acesso, 
                                                              tb_funcionarios_telefone,
                                                              tb_funcionarios_celular,
                                                              tb_funcionarios_cep,
                                                              tb_funcionarios_endereço,
                                                              tb_funcionarios_numero,
                                                              tb_funcionarios_complemento,
                                                              tb_funcionarios_bairro, 
                                                              tb_funcionarios_cidade,
                                                              tb_funcionarios_estado)
                                                              values(
                                                              @funcionarios_nome, 
                                                              @funcionarios_rg,
                                                              @funcionarios_cpf,
                                                              @funcionarios_email,
                                                              @funcionarios_senha,
                                                              @funcionarios_cargo, 
                                                              @funcionarios_nivel_acesso, 
                                                              @funcionarios_telefone,
                                                              @funcionarios_celular,
                                                              @funcionarios_cep,
                                                              @funcionarios_endereço,
                                                              @funcionarios_numero,
                                                              @funcionarios_complemento,
                                                              @funcionarios_bairro, 
                                                              @funcionarios_cidade,
                                                              @funcionarios_estado)";

                MySqlCommand executaMySql_Insert = new MySqlCommand(sql_insert, con);

                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_nome", nome);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_rg", rg);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_cpf", cpf);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_email", email);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_senha", senha);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_cargo", cargo);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_nivel_acesso", nivel_acesso);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_telefone", telefone);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_celular", celular);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_cep", cep);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_endereço", endereço);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_numero", numero);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_complemento", complemento);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_bairro", bairro);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_cidade", cidade);
                executaMySql_Insert.Parameters.AddWithValue("@funcionarios_estado", estado);


                executaMySql_Insert.ExecuteNonQuery();

                con.Close();



                MessageBox.Show("Cliente cadastrado com sucesso!");

                dtfun();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu o erro cadastrar " + erro);
            }
        }

        private void funcionarios_Load(object sender, EventArgs e)
        {
            dtfun();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox17.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox16.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();

        }
    }
}

