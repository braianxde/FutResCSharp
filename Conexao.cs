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
            //con.ConnectionString = "server=127.0.0.1;userid=azure;password=6#vWHD_$;database=projetointegrador4a;Port=49905";
            con.ConnectionString = "server=127.0.0.1;userid=azure;password=6#vWHD_$;database=localdb;Port=49905";
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
