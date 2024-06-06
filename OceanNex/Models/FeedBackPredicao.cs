namespace OceanNex.Models
{
    public class FeedBackPredicao
    {
        public int FeedBackPredicaoId { get; set; }

        public string StatusFeedBackPredicao { get; set;}

        public string DescricaoFeedBackPredicao { get; set;}

        public int? PredicaoId { get; set; }
        public Predicao? Predicao { get; set; }


        public int ContaId { get; set; }
        public Conta? Conta { get; set; }
    }
}
