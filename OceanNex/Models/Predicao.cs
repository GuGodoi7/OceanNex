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

        //1..N
        public virtual IEnumerable<Conta>? Conta { get; set; }
    }
}
