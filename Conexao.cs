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
            //con.ConnectionString = "Database=projetointegrador4a;Data Source=127.0.0.1:49394;User Id=azure;Password=6#vWHD_$";
            con.ConnectionString = "server=127.0.0.1;userid=azure;password=6#vWHD_$;database=projetointegrador4a;Port=49394";
            //con.ConnectionString = "server=localhost;user id=root;password=Braian123456;persistsecurityinfo=True;database=projetointegrador4a";
            //con.ConnectionString = "server=127.0.0.1;user id=azure;password=6#vWHD_$;database=projetointegrador4a";
        }
        //AAAAAAAAAAAAAAAAA
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
