using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home.Classes
{
    class Infetados
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool Check(string Rpaciente,int Rregiao, int Rinfecao, bool Rinfetado, bool Rrecuperado, bool Robito, int type)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE paciente = @externalId AND infecao = @infecao", conn);
            cmd.Parameters.AddWithValue("@externalId", Rpaciente.Trim(' '));
            cmd.Parameters.AddWithValue("@infecao", Rinfecao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            if(count > 0)
            {
                return true;
            }
            else {
                return false;
            }
            

        }

        public bool Insert(string Rpaciente, int Rregiao, int Rinfecao, bool Rrecuperado, bool Robito)
        {
            bool isSucess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO infetados (paciente, regiao, infecao, recuperado, obito) VALUES(@paciente, @regiao, @infecao, @recuperado, @obito)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@paciente", Rpaciente.Trim(' '));
                cmd.Parameters.AddWithValue("@regiao", Rregiao);
                cmd.Parameters.AddWithValue("@recuperado", Rrecuperado);
                cmd.Parameters.AddWithValue("@infecao", Rinfecao);
                cmd.Parameters.AddWithValue("@obito", Robito);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSucess;

        }

        public bool Update(string Rpaciente, int Rregiao, int Rinfecao, bool Rrecuperado, bool Robito)
        {
            bool isSucess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE infetados SET regiao = @regiao, recuperado= @recuperado, obito= @obito WHERE paciente = @externalId AND infecao = @infecao";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@externalId", Rpaciente.Trim(' '));
                cmd.Parameters.AddWithValue("@infecao", Rinfecao);
                cmd.Parameters.AddWithValue("@regiao", Rregiao);
                cmd.Parameters.AddWithValue("@recuperado", Rrecuperado);
                cmd.Parameters.AddWithValue("@obito", Robito);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSucess;

        }

        public int GetRecovers(int Rregiao)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE regiao = @regiao AND recuperado = 1 AND obito = 0", conn);
            cmd.Parameters.AddWithValue("@regiao", Rregiao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return count;
        }

        public int GetInfected(int Rregiao)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE regiao = @regiao AND recuperado = 0 AND obito = 0;", conn);
            cmd.Parameters.AddWithValue("@regiao", Rregiao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return count;
        }

        public int GetDeaths(int Rregiao)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE regiao = @regiao AND obito = 1", conn);
            cmd.Parameters.AddWithValue("@regiao", Rregiao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return count;
        }

        public int GetRecoversInfections(int Rinfecao)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE infecao = @infecao AND recuperado = 1 AND obito = 0", conn);
            cmd.Parameters.AddWithValue("@infecao ", Rinfecao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return count;
        }

        public int GetInfectedInfections(int Rinfecao)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE infecao = @infecao AND recuperado = 0 AND obito = 0;", conn);
            cmd.Parameters.AddWithValue("@infecao", Rinfecao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return count;
        }

        public int GetDeathsInfections(int Rinfecao)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM infetados WHERE infecao = @infecao AND obito = 1", conn);
            cmd.Parameters.AddWithValue("@infecao", Rinfecao);

            int count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return count;
        }

        public DataTable GetByRegions()
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable db = new DataTable();
            try
            {
                string sql = "SELECT * FROM regioes INNER JOIN infetados ON regioes.id = infetados.regiao INNER JOIN infecoes ON infetados.infecao = infecoes.id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(db);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return db;
        }

        public DataTable GetByInfection()
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable db = new DataTable();
            try
            {
                string sql = "SELECT * FROM regioes INNER JOIN infetados ON regioes.id = infetados.regiao INNER JOIN infecoes ON infetados.infecao = infecoes.id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(db);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return db;
        }

    }
}
