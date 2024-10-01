using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    [DataContract]
    public class GetCardByIdRequest
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
    }
}
