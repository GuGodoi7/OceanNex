namespace OceanNex.Models
{
    public class Postagem
    {
        public int PostagemId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Bibliografia { get; set; }


        public int ContaId { get; set; }
        public Biologo? Biologo { get; set; }


        public virtual IEnumerable<FeedBackPostagem>? FeedBackPostagens { get; set; }
    }
}
