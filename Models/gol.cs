using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class gol
    {
        public gol(int id, int tempo, int minuto, bool gol_contra, int id_jogador, int id_partida)
        {
            this.id = id;
            this.tempo = tempo;
            this.minuto = minuto;
            this.gol_contra = gol_contra;
            this.id_jogador = id_jogador;
            this.id_partida = id_partida;
        }

        public int id { get; set; }
        public int tempo { get; set; }
        public int minuto { get; set; }
        public Boolean gol_contra { get; set; }
        public int id_jogador { get; set; }
        public int id_partida { get; set; }
    }
}
