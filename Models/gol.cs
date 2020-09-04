using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class gol
    {
            private int id;
            private int tempo;
            private int minuto;
            private int gol_contra;
            private int id_jogador;
            private int id_partida;
            
            public gol ()
            {
            }
        
        public gol(int id, int tempo, int minuto, int gol_contra, int id_jogador, int id_partida)
        {
            this.id = id;
            this.tempo = tempo;
            this.minuto = minuto;
            this.gol_contra = gol_contra;
            this.id_jogador = id_jogador;
            this.id_partida = id_partida;
        }

        public int Id { get { return id; } set { id = value; }  }
        public int Tempo { get { return tempo; } set { tempo = value; } }
        public int Minuto { get { return minuto; } set { minuto = value; } }
        public int Gol_contra { get { return gol_contra; } set { gol_contra = value; } }
        public int Id_jogador { get { return id_jogador; } set { id_jogador = value; } }
        public int Id_partida { get { return id_partida; } set { id_partida = value; } }
    }
}