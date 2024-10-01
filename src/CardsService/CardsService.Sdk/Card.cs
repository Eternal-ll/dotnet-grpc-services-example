using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    [DataContract]
    public class Card
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public CardType Type { get; set; }
        [DataMember(Order = 3)]
        public string Sn { get; set; }
    }
}
