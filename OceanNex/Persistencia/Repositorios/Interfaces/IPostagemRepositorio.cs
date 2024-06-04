using OceanNex.Models;

namespace OceanNex.Persistencia.Repositorios.Interfaces
{
    public interface IPostagemRepositorio
    {
        IEnumerable<Postagem> GetAll();

        Postagem GetById(int? id);

        void Add(Postagem postagem);

        void Update(Postagem postagem);

        void Delete(Postagem postagem);
    }
}
