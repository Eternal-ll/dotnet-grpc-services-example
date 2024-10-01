using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    [DataContract]
    public class CardType
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
}
