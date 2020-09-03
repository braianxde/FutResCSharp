using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ProjetoIntegrador4A.Models;

namespace ProjetoIntegrador4A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clubeController : ControllerBase
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();



        //Retorna a lista de times de forma ascendente
        // https://localhost:44360/api/clube/Listarclubes

        [AcceptVerbs("GET")]
        [Route("Listarclubes")]
        public String Listarclubes()
        {
            try
            {
                List<clube> clubers = new List<clube>();
                cmd.CommandText = "SELECT *FROM clube ";
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clubers.Add(new clube(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetString(9), reader.GetString(10)));
                    }

                    {
                        IEnumerable<clube> clubeQuery =
                                           from clube in clubers
                                           orderby clube.nome ascending
                                           select clube;
                        List<string> xx = new List<string>();

                        foreach (clube x in clubeQuery)
                        {
                            xx.Add(x.nome);
                            continue;

                        }
                        return JsonConvert.SerializeObject(xx.ToArray(), Formatting.Indented);
                        reader.NextResult();
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.desconectar();
            }
            return "Nenhum clube encontrado";
        }
    }
}
