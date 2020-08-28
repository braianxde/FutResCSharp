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


namespace ProjetoIntegrador4A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                //QUERY SQL
                cmd.CommandText = "insert into usuario (id, nome, email, senha, token) values (@id, @nome, @email, @senha, @token)";

                //VINCULA O QUE FOI RECEBIDO NO WEBSERVICE EM BINDS PARA TROCAR NA QUERY
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@nome",usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@token", usuario.Token);

                //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

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

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(Usuario usuario)
        {
            try
            {
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
                //QUERY SQL
                cmd.CommandText = "delete from usuario where id = @id";

                //VINCULA O QUE FOI RECEBIDO NO WEBSERVICE EM BINDS PARA TROCAR NA QUERY
                cmd.Parameters.AddWithValue("@id",Id);

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
                        users.Add(new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
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
                List<Usuario> users = new List<Usuario>();
                int varint = 0;
                cmd.CommandText = "SELECT * FROM usuario";
                cmd.Connection = conexao.conectar();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        varint++;
                        users.Add(new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
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
    }
}
