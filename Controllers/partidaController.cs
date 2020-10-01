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
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conexao.conectar();

                cmd2.CommandText = "insert into partida (id, data_hora, id_mandante, id_visitante, id_rodada, gols_visitante, gols_mandante) values (@id, STR_TO_DATE(@data_hora,'%d/%m/%Y %h:%i:%s'), @id_mandante, @id_visitante, @id_rodada, @gols_visitante, @gols_mandante)";

                cmd2.Parameters.AddWithValue("@id", partida.Id);
                cmd2.Parameters.AddWithValue("@data_hora", partida.Data_hora);
                cmd2.Parameters.AddWithValue("@id_mandante", partida.Id_mandante);
                cmd2.Parameters.AddWithValue("@id_visitante", partida.Id_visitante);
                cmd2.Parameters.AddWithValue("@id_rodada", partida.Id_rodada);
                cmd2.Parameters.AddWithValue("@gols_visitante", partida.Gols_mandante);
                cmd2.Parameters.AddWithValue("@gols_mandante", partida.Gols_visitante);
                cmd2.ExecuteNonQuery();
                
                var gvis = partida.Gols_visitante;
                var gman = partida.Gols_mandante;


                MySqlCommand cmd3 = new MySqlCommand();
                cmd3.CommandText = "select pontos, vitorias, empates, derrotas, gols_pro, gols_contra from clube where id = @id_mandante";
                cmd3.Connection = conexao.conectar();
                cmd3.Parameters.AddWithValue("@id_mandante", partida.Id_mandante);

                MySqlDataReader reader = cmd3.ExecuteReader();

                var gpro = 0;
                var gcon = 0;
                var pts = 0;
                var vit = 0;
                var emp = 0;
                var der = 0;

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pts = reader.GetInt16(0);
                        vit = reader.GetInt16(1);
                        emp = reader.GetInt16(2);
                        der = reader.GetInt16(3);
                        gpro = reader.GetInt16(4);
                        gcon = reader.GetInt16(5);
                    }
                    reader.NextResult();
                }
                reader.Close();

                gpro += gman;
                gcon += gvis;

                if (gman > gvis)
                {
                    pts += 3;
                    vit += 1;
                }
                else if (gman == gvis)
                {
                    pts += 1;
                    emp += 1;
                }
                else
                {
                    der += 1;
                }


                MySqlCommand cmd4 = new MySqlCommand();
                cmd4.CommandText = "update clube set pontos = @pontos, vitorias = @vitorias, derrotas = @derrotas, empates = @empates, gols_pro = @gols_pro, gols_contra = @gols_contra where id = @id_mandante";
                cmd4.Connection = conexao.conectar();
                cmd4.Parameters.AddWithValue("@pontos", pts);
                cmd4.Parameters.AddWithValue("@vitorias", vit);
                cmd4.Parameters.AddWithValue("@empates", emp);
                cmd4.Parameters.AddWithValue("@derrotas", der);
                cmd4.Parameters.AddWithValue("@gols_pro", gpro);
                cmd4.Parameters.AddWithValue("@gols_contra", gcon);
                cmd4.Parameters.AddWithValue("@id_mandante", partida.Id_mandante);
                cmd4.ExecuteNonQuery();

                MySqlCommand cmd5 = new MySqlCommand();

                cmd5.CommandText = "select pontos, vitorias, empates, derrotas, gols_pro, gols_contra from clube where id = @id_visitante";
                cmd5.Connection = conexao.conectar();
                cmd5.Parameters.AddWithValue("@id_visitante", partida.Id_visitante);
                reader = cmd5.ExecuteReader();

                var gproV = 0;
                var vitV = 0;
                var ptsV = 0;
                var gconV = 0;
                var empV = 0;
                var derV = 0;

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ptsV = reader.GetInt16(0);
                        vitV = reader.GetInt16(1);
                        empV = reader.GetInt16(2);
                        derV = reader.GetInt16(3);
                        gproV = reader.GetInt16(4);
                        gconV = reader.GetInt16(5);
                    }
                    reader.NextResult();
                }
                reader.Close();


                gproV += gvis;
                gconV += gman;

                if (gman < gvis)
                {
                    ptsV += 3;
                    vitV += 1;
                }
                else if (gman == gvis)
                {
                    ptsV += 1;
                    empV += 1;
                }
                else
                {
                    derV += 1;
                }

                MySqlCommand cmd6 = new MySqlCommand();

                cmd6.CommandText = "update clube set pontos = @pontos, vitorias = @vitorias, derrotas = @derrotas, empates = @empates," +
                    " gols_pro = @gols_pro, gols_contra = @gols_contra where id = @id_visitante";
                cmd6.Connection = conexao.conectar();
                cmd6.Parameters.AddWithValue("@pontos", ptsV);
                cmd6.Parameters.AddWithValue("@vitorias", vitV);
                cmd6.Parameters.AddWithValue("@empates", empV);
                cmd6.Parameters.AddWithValue("@derrotas", derV);
                cmd6.Parameters.AddWithValue("@gols_pro", gproV);
                cmd6.Parameters.AddWithValue("@gols_contra", gconV);
                cmd6.Parameters.AddWithValue("@id_visitante", partida.Id_visitante);
                cmd6.ExecuteNonQuery();

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
                        partidas.Add(new partida(reader.GetInt32(0), reader.GetDateTime(1).ToString("dd/mm/yyyy hh:mm:ss"), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)));
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
