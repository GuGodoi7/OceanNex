using OceanNex.Models;
using OceanNex.Persistencia.Repositorios.Interfaces;

namespace OceanNex.Persistencia.Repositorios
{
    public class BiologoRepositorio : IBiologoRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public BiologoRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Biologo biologo)
        {
            _context.Add(biologo);

            _context.SaveChanges();
        }

        public void Delete(Biologo biologo)
        {
            _context.Remove(biologo);

            _context.SaveChanges();
        }

        public IEnumerable<Biologo> GetAll()
        {
            return _context.Biologo.ToList();
        }

        public Biologo GetById(int? id)
        {
            return _context.Biologo.Find(id);
        }

        public void Update(Biologo biologo)
        {
            _context.Update(biologo);

            _context.SaveChangesAsync();
        }
    }
}
