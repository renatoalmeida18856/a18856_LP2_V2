using Home.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class Fpacientes : Form
    {
        public Fpacientes()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Fpacientes_Load(object sender, EventArgs e)
        {

            // TODO: esta linha de código carrega dados na tabela 'infetadosDataSet.infecoes'. Você pode movê-la ou removê-la conforme necessário.
            this.infecoesTableAdapter.Fill(this.infetadosDataSet.infecoes);
            // TODO: esta linha de código carrega dados na tabela 'infetadosDataSet.regioes'. Você pode movê-la ou removê-la conforme necessário.
            this.regioesTableAdapter.Fill(this.infetadosDataSet.regioes);

        }

    }
}
