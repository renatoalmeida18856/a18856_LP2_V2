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

        Classes.Paciente p = new Classes.Paciente();

        private void button2_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Envia o formulario para a base de dados
            /// </summary>
            bool ValidPrimeiro = false;
            bool ValidUltimo = false;


            if (textBox5.Text != "")
            {
                p.PrimeiroNome = textBox5.Text;
                ValidPrimeiro = true;
            }
            else
            {
                ValidPrimeiro = false;
                MessageBox.Show("Preencha o campo primeiro nome.");
            }

            if (textBox4.Text != "")
            {
                ValidUltimo = true;
                p.UltimoNome = textBox4.Text;
            }
            else
            {
                ValidUltimo = false;

                MessageBox.Show("Preencha o campo último nome.");
            }

            p.Morada = textBox1.Text;
            p.Genero = comboBox1.Text;
            p.DataNasc = dateTimePicker1.Value;
            p.Infetado = checkBox1.Checked;

            // REVER
            p.Regiao = 1;

            bool sucess = p.Insert(p);
            if (sucess && ValidPrimeiro && ValidUltimo)
            {
                MessageBox.Show("Paciente Adicionado com sucesso.");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

            DataTable db = p.Select();
            dataGridView2.DataSource = db;
        }
    }
}
