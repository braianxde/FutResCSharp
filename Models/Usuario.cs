using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Model
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string email;
        private string senha;
        private string token;
        private int contador;

        public Usuario()
        {
        }

        public Usuario(int id, string nome, string email, string senha, string token, int contador)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.token = token;
            this.contador = contador;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Contador
        {
            get
            {
                return contador;
            }

            set
            {
                contador = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public string Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
            }
        }
    }
}
