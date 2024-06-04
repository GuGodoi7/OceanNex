using OceanNex.Models;

namespace OceanNex.Persistencia.Repositorios.Interfaces
{
    public interface IBiologoRepositorio
    {
        IEnumerable<Biologo> GetAll();

        Biologo GetById(int? id);

        void Add(Biologo biologo);

        void Update(Biologo biologo);

        void Delete(Biologo biologo);
    }
}
