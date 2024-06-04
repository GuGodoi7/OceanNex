using OceanNex.Models;
using OceanNex.Persistencia.Repositorios.Interfaces;

namespace OceanNex.Persistencia.Repositorios
{
    public class PredicaoRepositorio : IPredicaoRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public PredicaoRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Predicao predicao)
        {
            _context.Add(predicao);

            _context.SaveChanges();
        }

        public void Delete(Predicao predicao)
        {
            _context.Remove(predicao);

            _context.SaveChanges();
        }

        public IEnumerable<Predicao> GetAll()
        {
            return _context.Predicao.ToList();
        }

        public Predicao GetById(int? id)
        {
            return _context.Predicao.Find(id);
        }

        public void Update(Predicao predicao)
        {
            _context.Update(predicao);

            _context.SaveChangesAsync();
        }
    }
}
