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
    public class jogadorController : ControllerBase
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        [AcceptVerbs("POST")]

        [Route("InserirJogador")]
        public string InserirJogador (jogador jogador)
        {
            try
            {
                cmd.CommandText = "insert into jogador (id, nome, id_clube) values (@id, @nome, @id_clube)";

                cmd.Parameters.AddWithValue("@id", jogador.Id);
                cmd.Parameters.AddWithValue("@nome", jogador.Nome);
                cmd.Parameters.AddWithValue("@id_clube", jogador.Id_clube);
               
                cmd.Connection = conexao.conectar();

                cmd.ExecuteNonQuery();

                conexao.desconectar();

                return "Jogador inserido com Sucesso!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [AcceptVerbs("GET")]
        [Route("ConsultaJogadorPorClube/{id_clube}")]
        public string ConsultaJogadorPorClube(int Id_clube)
        {
            try
            {
                List<jogador> jogadores = new List<jogador>();
                int varint = 0;
                cmd.CommandText = "SELECT * FROM jogador where id_clube = @id_clube";
                cmd.Parameters.AddWithValue("@id_clube", Id_clube);
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        varint++;
                        jogadores.Add(new jogador(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2)));
                    }
                    reader.NextResult();
                }
                reader.Close();
                return JsonConvert.SerializeObject(jogadores, Formatting.Indented);
            }

            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexao.desconectar();
            }
            return "Partida sem gols!";

        }

    }   
}
