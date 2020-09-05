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
    public class partidaController : ControllerBase
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        [AcceptVerbs("POST")]

        [Route("InserirPartida")]
        public string InserirPartida(partida partida)
        {
            try
            {
                cmd.CommandText = "insert into partida (id, data_hora, id_mandante, id_visitante, id_rodada, gols_visitante, gols_mandante) values (@id, STR_TO_DATE(@data_hora,'%d/%m/%Y %h:%i:%s'), @id_mandante, @id_visitante, @id_rodada, @gols_visitante, @gols_mandante)";

                cmd.Parameters.AddWithValue("@id", partida.Id);
                cmd.Parameters.AddWithValue("@data_hora", partida.Data_hora);
                cmd.Parameters.AddWithValue("@id_mandante", partida.Id_mandante);
                cmd.Parameters.AddWithValue("@id_visitante", partida.Id_visitante);
                cmd.Parameters.AddWithValue("@id_rodada", partida.Id_rodada);
                cmd.Parameters.AddWithValue("@gols_visitante", partida.Gols_mandante);
                cmd.Parameters.AddWithValue("@gols_mandante", partida.Gols_visitante);

                cmd.Connection = conexao.conectar();

                cmd.ExecuteNonQuery();

                conexao.desconectar();

                return "Partida inserida com sucesso";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [AcceptVerbs("GET")]
        [Route("ConsultaPartidasPorRodada/{id_rodada}")]
        public string ConsultaPartidasPorRodada(int id_rodada)
        {
            try
            {
                List<partida> partidas = new List<partida>();
                int varint = 0;
                cmd.CommandText = "select p.id, p.data_hora, gols_mandante, gols_visitante, p.id_rodada, d.nome as nome_visitante , c.nome as nome_mandante, c.imagem as imagem_mandante, d.imagem as imagem_visitante from partida as p join clube as c on p.id_mandante = c.id join clube as d on p.id_visitante = d.id and id_rodada = @id_rodada";
                cmd.Parameters.AddWithValue("@id_rodada", id_rodada);
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        varint++;
                        partidas.Add(new partida(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)));
                    }
                    reader.NextResult();
                }
                reader.Close();
                return JsonConvert.SerializeObject(partidas, Formatting.Indented);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.desconectar();
            }
            return "Rodada sem partidas!";

        }
    }
}
