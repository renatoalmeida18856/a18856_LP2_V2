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

            DataTable db = p.Select();
            dataGridView2.DataSource = db;

            // TODO: esta linha de código carrega dados na tabela 'infetadosDataSet.infecoes'. Você pode movê-la ou removê-la conforme necessário.
            this.infecoesTableAdapter.Fill(this.infetadosDataSet.infecoes);
            // TODO: esta linha de código carrega dados na tabela 'infetadosDataSet.regioes'. Você pode movê-la ou removê-la conforme necessário.
            this.regioesTableAdapter.Fill(this.infetadosDataSet.regioes);

        }

        Classes.Paciente p = new Classes.Paciente();
        Classes.Infetados inf = new Classes.Infetados();


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

            p.Morada = textBox2.Text;
            p.Genero = comboBox1.Text;
            p.DataNasc = dateTimePicker1.Value;
            p.Infetado = checkBox1.Checked;
            p.Recuperado = true;
            p.Obito = true;
            p.Regiao = Int32.Parse(comboBox2.SelectedValue.ToString());
            p.Infecao = Int32.Parse(comboBox3.SelectedValue.ToString());

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

        private void button1_Click(object sender, EventArgs e)
        {

            p.Id = Int32.Parse(textBox8.Text);
            p.ExternalId = textBox7.Text;
            p.PrimeiroNome = textBox5.Text;
            p.UltimoNome = textBox4.Text;
            p.Morada = textBox2.Text;
            p.Genero = comboBox1.Text;
            p.DataNasc = dateTimePicker1.Value;
            p.Infetado = checkBox1.Checked;
            p.Recuperado = true;
            p.Obito = true;
            p.Regiao = Int32.Parse(comboBox2.SelectedValue.ToString());
            p.Infecao = Int32.Parse(comboBox3.SelectedValue.ToString());

            //if (p.Infetado)
            //{

                //bool check = inf.Check(p.ExternalId, p.Regiao, p.Infecao, p.Infetado, p.Recuperado, p.Obito , 1);
                //verifica se ja tem registo com esta infececao
                //se sim 
               // if (check)
                //{
                    //verifica se esta recuperado ou obito

                    //if (p.Recuperado)
                    //{

                    //}else if (p.Obito) {
                        
                   // }
                //}
               // else
                //{
                    //se nao, adiciona ha tabela infetados
                    //inf.Insert(p.ExternalId, p.Regiao, p.Infecao, p.Recuperado, p.Obito);
               // }

           // }

            bool sucess = p.Update(p);

            if (sucess)
            {
                MessageBox.Show("Paciente editado com sucesso.");
                DataTable db = p.Select();
                dataGridView2.DataSource = db;
            }
            else
            {
               MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button2.Hide();
            button1.Show();


            // Obter os dados para poder editar e obter informaçao
            int rowIndex = e.RowIndex;
            textBox8.Text = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
            textBox7.Text = dataGridView2.Rows[rowIndex].Cells[11].Value.ToString();
            textBox4.Text = dataGridView2.Rows[rowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView2.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[rowIndex].Cells[3].Value.ToString();
            //dateTimePicker1 = dataGridView2.Rows[rowIndex].Cells[4].Value();
            textBox2.Text = dataGridView2.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox2.SelectedIndex = Int32.Parse(dataGridView2.Rows[rowIndex].Cells[6].Value.ToString());
            comboBox3.SelectedIndex = Int32.Parse(dataGridView2.Rows[rowIndex].Cells[9].Value.ToString());

            if (dataGridView2.Rows[rowIndex].Cells[7].Value.ToString() == "1")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            if (dataGridView2.Rows[rowIndex].Cells[8].Value.ToString() == "1")
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }

            if (dataGridView2.Rows[rowIndex].Cells[10].Value.ToString() == "1")
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }

        }
    }
}
