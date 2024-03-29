﻿using System;
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

        [AcceptVerbs("GET")]
        [Route("Listarclubes")]
        public String Listarclubes()
        {
            try
            {
                UsuarioController user = new UsuarioController();
                bool sessao = user.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                List<clube> clubers = new List<clube>();
                cmd.CommandText = "select * from clube order by pontos desc, vitorias desc, empates desc, derrotas desc, (gols_pro-gols_contra) desc";
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clubers.Add(new clube(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7)));
                    }
                    reader.NextResult();
                }
                reader.Close();
                return JsonConvert.SerializeObject(clubers, Formatting.Indented);
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

        [AcceptVerbs("PUT")]
        [Route("AtualizaClube")]
        public string AtualizaClube(clube clube)
        {
            try
            {

                UsuarioController user = new UsuarioController();
                bool sessao = user.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                cmd.CommandText = " update clube set pontos = @pontos, vitorias = @vitorias, derrotas = @derrotas, empates = @empates, gols_pro = @gols_pro, gols_contra = @gols_contra where id = @id";

                cmd.Parameters.AddWithValue("@id", clube.Id);
                cmd.Parameters.AddWithValue("@pontos", clube.Pontos);
                cmd.Parameters.AddWithValue("@vitorias", clube.Vitorias);
                cmd.Parameters.AddWithValue("@derrotas", clube.Derrotas);
                cmd.Parameters.AddWithValue("@empates", clube.Empates);
                cmd.Parameters.AddWithValue("@gols_pro", clube.Gols_pro);
                cmd.Parameters.AddWithValue("@gols_contra", clube.Gols_contra);

                cmd.Connection = conexao.conectar();
                cmd.ExecuteNonQuery();
                
                conexao.desconectar();

                return "Clube atualizado com sucesso!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
