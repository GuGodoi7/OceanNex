using OceanNex.Models;

namespace OceanNex.Persistencia.Repositorios.Interfaces
{
    public interface IFeedBackPredicaoRepositorio
    {
        IEnumerable<FeedBackPredicao> GetAll();

        FeedBackPredicao GetById(int? id);

        void Add(FeedBackPredicao feedBackPredicao);

        void Update(FeedBackPredicao feedBackPredicao);

        void Delete(FeedBackPredicao feedBackPredicao);
    }
}
