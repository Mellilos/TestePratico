using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace API_ANIMAIS
{
    public class ComandosSql
    {
        public SqlConnection Conecta()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "testepratico.database.windows.net";
                builder.UserID = "Vithanos";
                builder.Password = "W93@87c0";
                builder.InitialCatalog = "testepratico";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
            
                return connection;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            
        }

        public List<Animais> Seleciona()
        {
            List<Animais> animais = new List<Animais>();
            try
            {
                String sql = "SELECT * from [dbo].[Animais] WHERE apagado = 0";
                var connection = Conecta();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animais.Add(new Animais(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetBoolean(4)));
                        }
                    }
                }
                return animais;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public string Insere(string nome, string classe, int pes, int voa)
        {
            try
            {
                String sql = "insert into [dbo].[Animais] (nome, classe, pes, voa) values ('"+nome+"','"+classe+
                "',"+pes.ToString()+","+voa.ToString()+")";

                SqlConnection connection = Conecta();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return "Inserido";

            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }
        public string Altera(int id_a, string nome, string classe, int pes, int voa)
        {
            try
            {
                String sql = "UPDATE [dbo].[animais] SET nome = '" + nome + "'," +
                    "classe = '"+classe+"',pes = "+pes.ToString()+",voa = "+voa.ToString()+"" +
                    "WHERE id_a="+id_a.ToString()+";";


                SqlConnection connection = Conecta();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return "Alterado";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string Apaga(int id_a)
        {
            try
            {
                String sql = "UPDATE [dbo].[animais] SET apagado = 1 " +
                    "WHERE id_a=" + id_a.ToString() + ";";


                SqlConnection connection = Conecta();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return "Apagado";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

       
    }
}
