using System.IO;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;

namespace OceanNex.Models
{
    public class Predicao
    {
        public int PredicaoId { get; set; }

        public string TaxaPredicao { get; set; }

        public string DescricaoPredicao { get; set; }



        public int ContaId { get; set; }
        public Conta? Conta { get; set; }

    }
}
