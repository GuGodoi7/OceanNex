using Microsoft.EntityFrameworkCore;
using OceanNex.Models;
using OceanNex.Persistencia.Repositorios.Interfaces;

public class FeedBackPredicaoRepositorio : IFeedBackPredicaoRepositorio
{
    private readonly DbContext _context; // Assumindo que você está usando Entity Framework

    public FeedBackPredicaoRepositorio(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<FeedBackPredicao> GetAll()
    {
        return _context.Set<FeedBackPredicao>().ToList();
    }

    public FeedBackPredicao GetById(int? id)
    {
        return _context.Set<FeedBackPredicao>().Find(id);
    }

    public void Add(FeedBackPredicao feedBackPredicao)
    {
        _context.Set<FeedBackPredicao>().Add(feedBackPredicao);
        _context.SaveChanges();
    }

    public void Update(FeedBackPredicao feedBackPredicao)
    {
        _context.Set<FeedBackPredicao>().Update(feedBackPredicao);
        _context.SaveChanges();
    }

    public void Delete(FeedBackPredicao feedBackPredicao)
    {
        _context.Set<FeedBackPredicao>().Remove(feedBackPredicao);
        _context.SaveChanges();
    }

    // Implementação do método GetPredicoes
    public IEnumerable<Predicao> GetPredicoes()
    {
        return _context.Set<Predicao>().ToList();
    }
}
