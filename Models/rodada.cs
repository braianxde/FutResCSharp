using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class rodada
    {
        public rodada(int id, DateTime data_inicio, DateTime data_fim, int id_campeonato, string nome_rodada)
        {
            this.id = id;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.id_campeonato = id_campeonato;
            this.nome_rodada = nome_rodada;
        }

        public rodada(int id, string nome_rodada)
        {
            this.id = id;
            this.nome_rodada = nome_rodada;
        }

        public int id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public int id_campeonato { get; set; }
        public string nome_rodada { get; set; }
    }
}
