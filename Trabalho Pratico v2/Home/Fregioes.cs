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
        Classes.Infetados inf = new Classes.Infetados();

        private void Fregioes_Load(object sender, EventArgs e)
        {
            DataTable db = r.Select();
            dataGridView2.DataSource = db;

            //ao click de cada regiao
            label3.Text = inf.GetInfected(1).ToString();
            label4.Text = inf.GetRecovers(1).ToString();
            label5.Text = inf.GetDeaths(1).ToString();


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
       

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fpacientes fp = new Fpacientes();
            fp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fregioes fp = new Fregioes();
            fp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finfecoes fp = new Finfecoes();
            fp.Show();
        }
    }
}
