using System.Collections.Generic;
using DioFilmes.Interface;
using DioFilmes.Model;

namespace DioFilmes.Repository
{
    public class MovieRepository : IRepository<MovieModel>
    {
        private readonly List<MovieModel> _moviesList = new List<MovieModel>();

        public void Atualiza(int id, MovieModel objeto)
        {
            _moviesList[id] = objeto;
        }

        public void Exclui(int id)
        {
            _moviesList[id].Excluir();
        }

        public void Insere(MovieModel objeto)
        {
            _moviesList.Add(objeto);
        }

        public List<MovieModel> Lista()
        {
            return _moviesList;
        }

        public int ProximoId()
        {
            return _moviesList.Count;
        }

        public MovieModel RetornaPorId(int id)
        {
            return _moviesList[id];
        }
    }
}