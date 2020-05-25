using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Classes
{
    class Infetados
    {
        public int id;
        public int paciente;
        public int regiao;
        public int infecao;
        public bool infetado;
        public bool recuperado;
        public bool obito;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool Check(int Rpaciente,int Rregiao, int Rinfecao, bool Rinfetado, bool Rrecuperado, bool Robito)
        {

            bool isSucess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "SELECT * FROM infetados WHERE `paciente` = @paciente AND `regiao` = @regiao AND `infecao` = @infecao AND  `recuperado` = @recuperado AND `obito` = @obito";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@paciente", Rpaciente);
                cmd.Parameters.AddWithValue("@regiao", Rregiao);
                cmd.Parameters.AddWithValue("@infecao", Rinfecao);
                cmd.Parameters.AddWithValue("@infetado", Rinfetado);
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
    }
}
