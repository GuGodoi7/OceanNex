using OceanNex.Models;

namespace OceanNex.Persistencia.Repositorios.Interfaces
{
    public interface IFeedBackPostagemRepositorio
    {
      

        IEnumerable<FeedBackPostagem> GetAll();

        FeedBackPostagem GetById(int? id);

        void Add(FeedBackPostagem feedBackPostagem);

        void Update(FeedBackPostagem feedBackPostagem);

        void Delete(FeedBackPostagem feedBackPostagem);
    }
}
