using Microsoft.EntityFrameworkCore;
using OceanNex.Models;
using OceanNex.Persistencia.Mapeamento;

namespace OceanNex.Persistencia
{
    public class OracleFIAPDbContext : DbContext
    {
        public DbSet<Conta> Conta  { get; set; }
        public DbSet<Biologo> Biologo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<FeedBackPredicao> FeedBackPredicao { get; set; }
        public DbSet<FeedBackPostagem> FeedBackPostagem { get; set; }


        public DbSet<Predicao> Predicao { get; set; }

        public DbSet<Postagem> Postagem { get; set; }


        public OracleFIAPDbContext(DbContextOptions<OracleFIAPDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BiologoMapeamento());
            modelBuilder.ApplyConfiguration(new ContaMapeamento());
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new FeedBackPostagemMapeamento());
            modelBuilder.ApplyConfiguration(new FeedBackPredicaoMapeamento());
            modelBuilder.ApplyConfiguration(new PostagemMapeamento());
            modelBuilder.ApplyConfiguration(new PredicaoMapeamento());
        }
    }
}
