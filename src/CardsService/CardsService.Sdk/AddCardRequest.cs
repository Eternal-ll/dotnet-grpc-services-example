using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    [DataContract]
    public class AddCardRequest
    {
        [DataMember(Order = 1)]
        public int CardTypeId { get; set; }
    }
}
