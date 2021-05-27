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
        private int pontos;
        private int vitorias;
        private int empates;
        private int derrotas;
        private int gols_pro;
        private int gols_contra;
        public clube ()
        { }

        public clube(int id, string nome, int pontos, int vitorias, int empates, int derrotas, int gols_pro, int gols_contra)
        {
            this.id = id;
            this.nome = nome;
            this.pontos = pontos;
            this.vitorias = vitorias;
            this.empates = empates;
            this.derrotas = derrotas;
            this.gols_pro = gols_pro;
            this.gols_contra = gols_contra;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public int Pontos { get { return pontos; } set { pontos = value; } }
        public int Vitorias { get { return vitorias; } set { vitorias = value; } }
        public int Empates { get { return empates; } set { empates = value; } }
        public int Derrotas { get { return derrotas; } set { derrotas = value; } }
        public int Gols_pro { get { return gols_pro; } set { gols_pro = value; } }
        public int Gols_contra { get { return gols_contra; } set { gols_contra = value; } }
    }
}
