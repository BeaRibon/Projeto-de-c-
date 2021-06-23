using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcionarios funcionarios = new funcionarios();
            this.Hide();
            funcionarios.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fornecedores fornecedores = new fornecedores();
            this.Hide();
            fornecedores.ShowDialog();
        }
    }
}
