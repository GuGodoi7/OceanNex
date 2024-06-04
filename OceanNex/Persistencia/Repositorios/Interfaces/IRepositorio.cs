using System.Collections;

namespace OceanNex.Persistencia.Repositorios.Interfaces
{
    public interface IRepositorio<T>
    {

        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
