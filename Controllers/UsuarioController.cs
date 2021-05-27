using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ProjetoIntegrador4A.Model;
using ProjetoIntegrador4A.Models;

namespace ProjetoIntegrador4A.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    //adicionadoComentario
    public class UsuarioController : ControllerBase
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();  
           
        [AcceptVerbs("POST")]

        //A ROTA FICARA ASSIM https://localhost:44360/api/Usuario/CadastrarUsuario
        //OLA 
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(Usuario usuario)
        {
            try
            {
                bool sessao = this.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }
                //QUERY SQL
                cmd.CommandText = "insert into usuario (id, nome, email, senha, token, contador) values (@id, @nome, @email, @senha, @token, 0)";

                //VINCULA O QUE FOI RECEBIDO NO WEBSERVICE EM BINDS PARA TROCAR NA QUERY
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(usuario.Nome + usuario.Email + usuario.Senha);
                
                cmd.Parameters.AddWithValue("@token", System.Convert.ToBase64String(plainTextBytes).Substring(0, 49));

                //SE CONECTA NO BANCO
                cmd.Connection = conexao.conectar();
                //EXECUTA A QUERY
                cmd.ExecuteNonQuery();
                //DESCONECTA NO BANCO
                conexao.desconectar();

                return "Usuário cadastrado com sucesso!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [Route("Logar")]
        public string Logar(Usuario usuario)
        {
            try
            {

                cmd.CommandText = "SELECT token, contador FROM usuario where email = @email and senha = @senha";
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();
                var token = "";
                var cont = 0;
                while (reader.Read())
                {
                    if (reader.GetString(0) != null)
                    {
                        token = reader.GetString(0);
                        cont = reader.GetInt16(1);
                    }
                }
                reader.Close();


                if (token != "") {
                    
                    cont += 1;

                    cmd.CommandText = "update usuario set contador = @contador where token = @token";
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@contador", cont);
                    cmd.Connection = conexao.conectar();
                    cmd.ExecuteNonQuery();
                    conexao.desconectar();
                }
                string[] tokenArray = { token };

                return JsonConvert.SerializeObject(tokenArray, Formatting.Indented);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(Usuario usuario)
        {
            try
            {

                bool sessao = this.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                //QUERY SQL
                cmd.CommandText = "update usuario set nome = @nome, email = @email, senha = @senha, token = @token where id = @id";

                //VINCULA O QUE FOI RECEBIDO NO WEBSERVICE EM BINDS PARA TROCAR NA QUERY
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@token", usuario.Token);

                //SE CONECTA NO BANCO
                cmd.Connection = conexao.conectar();
                //EXECUTA A QUERY
                cmd.ExecuteNonQuery();
                //DESCONECTA NO BANCO
                conexao.desconectar();

                return "Usuário alterado com sucesso!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{id}")]
        public string ExcluirUsuario(int Id)
        {
            try
            {

                bool sessao = this.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                //QUERY SQL
                cmd.CommandText = "delete from usuario where id = @id";

                //VINCULA O QUE FOI RECEBIDO NO WEBSERVICE EM BINDS PARA TROCAR NA QUERY
                cmd.Parameters.AddWithValue("@id", Id);

                //SE CONECTA NO BANCO
                cmd.Connection = conexao.conectar();
                //EXECUTA A QUERY
                cmd.ExecuteNonQuery();
                //DESCONECTA NO BANCO
                conexao.desconectar();

                return "Usuário excluido com sucesso!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{id}")]
        public string ConsultarUsuarioPorCodigo(int Id)
        {
            try
            {
                bool sessao = this.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                List<Usuario> users = new List<Usuario>();
                int varint = 0;
                cmd.CommandText = "SELECT * FROM usuario where id = @id";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        varint++;
                        users.Add(new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
                    }

                    reader.NextResult();
                }

                reader.Close();
                return JsonConvert.SerializeObject(users, Formatting.Indented);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.desconectar();
            }

            return "Nenhum usuario encontrado";

        }
        
        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public String ConsultarUsuarios()
        {
            try
            {
                bool sessao = this.validaSessao(this.Request.Headers["Authorization"]);

                if (!sessao)
                {
                    return "Usuario nao esta logado";
                }

                List<Usuario> users = new List<Usuario>();
                cmd.CommandText = "SELECT id, nome, email, senha, token, contador FROM usuario";
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
                    }

                    reader.NextResult();
                }

                reader.Close();
                return JsonConvert.SerializeObject(users, Formatting.Indented);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.desconectar();
            }

            return "Nenhum usuario encontrado";

        }

        public bool validaSessao( string authHeader)
        {
            if (authHeader != "")
            {
                cmd.CommandText = "SELECT nome FROM usuario where token = @token";
                cmd.Parameters.AddWithValue("@token", authHeader);
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                string usuario = "";

                while (reader.Read())
                {
                    usuario = reader.GetString(0);
                }
                reader.Close();

                if (usuario != "")
                {
                    return true;
                }

            }

            return false;
        }
    }
}
