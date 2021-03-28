using System;
using DioFilmes.Enum;

namespace DioFilmes.Model
{
    public class MovieModel : BaseModel
    {
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private EnumGenero Genero { get; set; }

        public MovieModel(int id, string titulo, string descricao, int ano, EnumGenero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Genero = genero;
            this.Excluido = false;
        }

        public override string ToString()
        {
            var retorno = "";

            retorno += "ID: " + this.Id + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Excluído: " + (this.Excluido ? "Sim" : "Não");

            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}