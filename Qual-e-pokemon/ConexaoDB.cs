using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace quiz_pokemon
{
     class ConexaoDB
    {
        private string conexaoBanco = "Server=localhost; Database=usuarios_db; Uid=root; Pwd='';";

        public MySqlConnection Conectar()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexaoBanco);
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                return null;
            }
            
        }
    }
}
