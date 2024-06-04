using System.ComponentModel.DataAnnotations.Schema;

namespace OceanNex.Models
{
    public class Postagem
    {
        public int PostagemId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public string Bibliografia { get;}

        //1..N
        public virtual IEnumerable<Biologo>? Biologo { get; set; }
    }
}
