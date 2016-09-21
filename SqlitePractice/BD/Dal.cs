using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqlitePractice.BD
{
    class Dal
    {

        public SQLiteConnection conn = new SQLiteConnection("Data Source=database/cadastro.db");
        private String sql;
        Boolean retorno = false;
        SQLiteDataReader reader;


        public Boolean insert(Modelo m)
        {
            conn.Open();
            sql = "INSERT INTO pessoas (name, cpf, rua, num, bairro, cidade) " +
            "VALUES ( " +
            "'" + m.nome + "', " +
            "'" + m.cpf + "', " +
            "'" + m.rua + "', " +
            "'" + m.num + "', " +
            "'" + m.bairro + "', " +
            "'" + m.cidade + "');";

            SQLiteCommand comand = new SQLiteCommand(sql, conn);
            try
            {
                comand.ExecuteNonQuery();
                retorno = true;               
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
                return retorno;
        }



        public SQLiteDataReader select ()
        {
            conn.Open();
            sql = "Select * from pessoas";
            SQLiteCommand com = new SQLiteCommand(sql, conn);           
            try
            {
                reader = com.ExecuteReader();
            }
            catch(SQLiteException ex) {
                throw new SQLiteException("erro : " + ex.Message);            
            }
            return reader;
        }


        public Boolean delete(String id) {
            sql = "delete from pessoas where id = '" + id + "'";
            SQLiteCommand com = new SQLiteCommand(sql, conn);
            try
            {
                conn.Open();
                com.ExecuteNonQuery();
                retorno = true;
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException("erro : " + ex.Message);
            }
            finally
            {
                conn.Close();              
            }
            return retorno;        
        }
    }
}
