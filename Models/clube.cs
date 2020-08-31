using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace ProjetoIntegrador4A.Models
{
    public class clube
    {
        public clube(int id, string nome, string cidade, int pontos, int vitorias, int empates, int derrotas, int gols_pro, int gols_contra, string nome_tecnico, string imagem)
        {
            this.id = id;
            this.nome = nome;
            this.cidade = cidade;
            this.pontos = pontos;
            this.vitorias = vitorias;
            this.empates = empates;
            this.derrotas = derrotas;
            this.gols_pro = gols_pro;
            this.gols_contra = gols_contra;
            this.nome_tecnico = nome_tecnico;
            this.imagem = imagem;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public int pontos { get; set; }
        public int vitorias { get; set; }
        public int empates { get; set; }
        public int derrotas { get; set; }
        public int gols_pro { get; set; }
        public int gols_contra { get; set; }
        public string nome_tecnico { get; set; }
        public string imagem { get; set; }
    }
}
