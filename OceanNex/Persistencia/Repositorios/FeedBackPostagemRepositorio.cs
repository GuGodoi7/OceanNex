using OceanNex.Models;
using OceanNex.Persistencia.Repositorios.Interfaces;

namespace OceanNex.Persistencia.Repositorios
{
    public class FeedBackPostagemRepositorio : IFeedBackPostagemRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public FeedBackPostagemRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(FeedBackPostagem feedBackpostagem)
        {
            _context.Add(feedBackpostagem);

            _context.SaveChanges();
        }

        public void Delete(FeedBackPostagem feedBackpostagem)
        {
            _context.Remove(feedBackpostagem);

            _context.SaveChanges();
        }

        public IEnumerable<FeedBackPostagem> GetAll()
        {
            return _context.FeedBackPostagem.ToList();
        }

        public FeedBackPostagem GetById(int? id)
        {
            return _context.FeedBackPostagem.Find(id);
        }

        public void Update(FeedBackPostagem feedBackpostagem)
        {
            _context.Update(feedBackpostagem);

            _context.SaveChangesAsync();
        }
    }
}

