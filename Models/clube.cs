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
        private int id;
        private string nome;
        private string cidade;
        private int pontos;
        private int vitorias;
        private int empates;
        private int derrotas;
        private int gols_pro;
        private int gols_contra;
        private string nome_tecnico;
        private string imagem;

        public clube ()
        { }

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

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        public int Pontos { get { return pontos; } set { pontos = value; } }
        public int Vitorias { get { return vitorias; } set { vitorias = value; } }
        public int Empates { get { return empates; } set { empates = value; } }
        public int Derrotas { get { return derrotas; } set { derrotas = value; } }
        public int Gols_pro { get { return gols_pro; } set { gols_pro = value; } }
        public int Gols_contra { get { return gols_contra; } set { gols_contra = value; } }
        public string Nome_tecnico { get { return nome_tecnico; } set { nome_tecnico = value; } }
        public string Imagem { get { return imagem; } set { imagem = value; } }
    }
}
