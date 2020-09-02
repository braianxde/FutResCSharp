using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class partida
    {
        public partida(int id, DateTime data_hora, int id_mandante, int id_visitante, int gols_mandante, int gols_visitante, int id_rodada)
        {
            this.id = id;
            this.data_hora = data_hora;
            this.id_mandante = id_mandante;
            this.id_visitante = id_visitante;
            this.gols_mandante = gols_mandante;
            this.gols_visitante = gols_visitante;
            this.id_rodada = id_rodada;
        }

        public int id { get; set; }
        public DateTime data_hora { get; set; }
        public int id_mandante { get; set; }
        public int id_visitante { get; set; }
        public int gols_mandante { get; set; }
        public int gols_visitante { get; set; }
        public int id_rodada { get; set; }
    }
}
