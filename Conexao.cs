using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoIntegrador4A
{
    public class Conexao
    {
        MySqlConnection con = new MySqlConnection();
        public Conexao()
        {
            con.ConnectionString = "server=localhost;user id=root;password=Braian123456;persistsecurityinfo=True;database=projetointegrador4a";
        }
        //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        public MySqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Close();
            }

        }
    }
}
