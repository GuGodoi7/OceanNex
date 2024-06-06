using OceanNex.Interfaces;

namespace OceanNex.Models
{
    public abstract class Conta : ILogin
    {
        public int ContaId { get; set; }
        public string NomeConta { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual void Login()
        { }

        public virtual IEnumerable<Predicao>? Predicao { get; set; }
        public virtual IEnumerable<FeedBackPostagem>? FeedBackPostagem { get; set; }
        public virtual IEnumerable<FeedBackPredicao>? FeedBackPredicao { get; set; }
    }
}
