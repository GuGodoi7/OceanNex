using OceanNex.Interfaces;

namespace OceanNex.Models
{
    public class Biologo : Conta, ILogin
    {
        public long NumeroRegistro { get; set; }

        public long CPF { get; set; }
        public string CRBio { get; set; }

        //1..N
        public virtual IEnumerable<Postagem>? Postagens { get; set; }
        public override void Login()
        {
            Console.WriteLine($"Biólogo {NomeConta} logado com sucesso.");
        }
    }
}
