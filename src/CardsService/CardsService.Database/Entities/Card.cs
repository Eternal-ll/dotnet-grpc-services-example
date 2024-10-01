namespace CardsService.Database.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int CardTypeId { get; set; }
        public string Sn { get; set; }
    }
}
