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
    public class rodadaController : ControllerBase
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        [AcceptVerbs("GET")]
        [Route("ListarRodadas")]
        public String ListarRodadas()
        {
            try
            {
                UsuarioController user = new UsuarioController();
                bool sessao = user.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                List<rodada> rodadas = new List<rodada>();
                cmd.CommandText = "select id, nome_rodada from rodada where data_inicio < NOW() order by nome_rodada ASC";
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rodadas.Add(new rodada(reader.GetInt32(0), reader.GetString(1)));
                    }
                    reader.NextResult();
                }
                reader.Close();
                return JsonConvert.SerializeObject(rodadas, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.desconectar();
            }
        }
    }
}
