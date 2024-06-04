namespace OceanNex.Models
{
    public class FeedBackPredicao
    {
        public int FeedBackPredicaoId { get; set; }

        public string StatusFeedBackPredicao { get; set;}

        public string DescricaoFeedBackPredicao { get; set;}

        //1..1
        public int? PredicaoId { get; set; }
        public Predicao? Predicao { get; set; }
    }
}
