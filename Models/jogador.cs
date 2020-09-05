using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class jogador
    {
        private int id;
        private string nome;
        private int id_clube;

        public jogador ()
        { }

        public jogador(int id, string nome, int id_clube)
        {
            this.id = id;
            this.nome = nome;
            this.id_clube = id_clube;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public int Id_clube { get { return id_clube; } set { id_clube = value; } }
    }
}
