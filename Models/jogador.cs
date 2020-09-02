using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class jogador
    {
        public jogador(int id, string nome, int id_clube)
        {
            this.id = id;
            this.nome = nome;
            this.id_clube = id_clube;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public int id_clube { get; set; }
    }
}
