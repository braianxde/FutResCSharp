using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class campeonato
    {
        public campeonato(int id, string nome_camp, int ano)
        {
            this.id = id;
            this.nome_camp = nome_camp;
            this.ano = ano;
        }

        public int id { get; set; }
        public string nome_camp { get; set; }
        public int ano { get; set; }
    }
}
