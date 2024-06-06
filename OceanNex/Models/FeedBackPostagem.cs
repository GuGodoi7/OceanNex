namespace OceanNex.Models
{
    public class FeedBackPostagem
    {
        public int FeedBackPostagemId { get; set; }

        public string StatusFeedBackPostagem { get; set; }

        public string DescricaoFeedBackPostagem { get; set; }

        public int ContaId { get; set; }
        public Conta? Conta { get; set; }

        public int PostagemId { get; set; }
        public Postagem? Postagem { get; set; }
    }
}