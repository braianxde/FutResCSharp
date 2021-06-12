using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4A.Models
{
    public class partida
    {
        private int id;
        private string data_hora;
        private int id_mandante;
        private int id_visitante;
        private int gols_mandante;
        private int gols_visitante;
        private int id_rodada;
        private string nome_visitante;
        private string nome_mandante;

        public partida()
        {

        }

        public partida(int id, string data_hora, int id_mandante, int id_visitante, int gols_mandante, int gols_visitante, int id_rodada, string nome_visitante, string nome_mandante)
        {
            this.id = id;
            this.data_hora = data_hora;
            this.id_mandante = id_mandante;
            this.id_visitante = id_visitante;
            this.gols_mandante = gols_mandante;
            this.gols_visitante = gols_visitante;
            this.id_rodada = id_rodada;
            this.nome_visitante = nome_visitante;
            this.nome_mandante = nome_mandante;
        }

        public partida(int id, string data_hora, int gols_mandante, int gols_visitante, int id_rodada, string nome_visitante, string nome_mandante)
        {
            this.id = id;
            this.data_hora = data_hora;
            this.gols_mandante = gols_mandante;
            this.gols_visitante = gols_visitante;
            this.id_rodada = id_rodada;
            this.nome_visitante = nome_visitante;
            this.nome_mandante = nome_mandante;
        }

        public partida(int id, string data_hora, int id_mandante, int id_visitante, int gols_mandante, int gols_visitante, int id_rodada)
        {
            this.id = id;
            this.data_hora = data_hora;
            this.id_mandante = id_mandante;
            this.id_visitante = id_visitante;
            this.gols_mandante = gols_mandante;
            this.gols_visitante = gols_visitante;
            this.id_rodada = id_rodada;
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

        public string Data_hora
        {
            get
            {
                return data_hora;
            }

            set
            {
                data_hora = value;
            }
        }

        public int Id_mandante
        {
            get
            {
                return id_mandante;
            }

            set
            {
                id_mandante = value;
            }
        }

        public int Id_rodada
        {
            get
            {
                return id_rodada;
            }

            set
            {
                id_rodada = value;
            }
        }

        public int Id_visitante
        {
            get
            {
                return id_visitante;
            }

            set
            {
                id_visitante = value;
            }
        }

        public int Gols_visitante
        {
            get
            {
                return gols_visitante;
            }

            set
            {
                gols_visitante = value;
            }
        }

        public int Gols_mandante
        {
            get
            {
                return gols_mandante;
            }

            set
            {
                gols_mandante = value;
            }
        }

        public string Nome_visitante
        {
            get
            {
                return nome_visitante;
            }

            set
            {
                nome_visitante = value;
            }
        }

        public string Nome_mandante
        {
            get
            {
                return nome_mandante;
            }

            set
            {
                nome_mandante = value;
            }
        }
    }
}
