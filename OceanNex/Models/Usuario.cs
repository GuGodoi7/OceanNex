using OceanNex.Interfaces;

namespace OceanNex.Models
{
    public class Usuario : Conta,  ILogin
    {
        public long Telefone { get; set; }

        public override void Login()
        {
            Console.WriteLine($"Usuário {NomeConta} logado com sucesso.");
        }
    }
}
