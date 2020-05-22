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
    public partial class Fregioes : Form
    {
        public Fregioes()
        {
            InitializeComponent();
        }

        Classes.Regioes r = new Classes.Regioes();

        private void Fregioes_Load(object sender, EventArgs e)
        {
            DataTable db = r.Select();
            dataGridView2.DataSource = db;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            r.Nome = textBox8.Text;
            r.Populacao = Int32.Parse(textBox5.Text);

            bool sucess = r.Insert(r);
            if (sucess)
            {
                MessageBox.Show("Regiao adicionada com sucesso.");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

            DataTable db = r.Select();
            dataGridView2.DataSource = db;
        }
    }
}
