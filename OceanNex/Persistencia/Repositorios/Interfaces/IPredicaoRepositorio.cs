using OceanNex.Models;

namespace OceanNex.Persistencia.Repositorios.Interfaces
{
    public interface IPredicaoRepositorio
    {
        IEnumerable<Predicao> GetAll();

        Predicao GetById(int? id);

        void Add(Predicao predicao);

        void Update(Predicao predicao);

        void Delete(Predicao predicao);
    }
}
