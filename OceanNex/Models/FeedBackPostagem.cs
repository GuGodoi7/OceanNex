namespace OceanNex.Models
{
    public class FeedBackPostagem
    {
        public int FeedBackPostagemId { get; set; }

        public string StatusFeedBackPostagem { get; set; }

        public string DescricaoFeedBackPostagem { get; set; }

        //1..N
        public virtual IEnumerable<Conta>? Conta { get; set; }
    }
}
