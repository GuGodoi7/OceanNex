using OceanNex.Models;
using OceanNex.Persistencia.Repositorios.Interfaces;

namespace OceanNex.Persistencia.Repositorios
{
    public class PostagemRepositorio : IPostagemRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public PostagemRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Postagem postagem)
        {
            _context.Add(postagem);

            _context.SaveChanges();
        }

        public void Delete(Postagem postagem)
        {
            _context.Remove(postagem);

            _context.SaveChanges();
        }

        public IEnumerable<Postagem> GetAll()
        {
            return _context.Postagem.ToList();
        }

        public Postagem GetById(int? id)
        {
            return _context.Postagem.Find(id);
        }

        public void Update(Postagem postagem)
        {
            _context.Update(postagem);

            _context.SaveChangesAsync();
        }
    }
}

