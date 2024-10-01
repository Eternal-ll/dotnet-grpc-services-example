using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    [DataContract]
    public class GetCardsRequest
    {
        public GetCardsRequest()
        {
            
        }
        public GetCardsRequest(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        [DataMember(Order = 1)]
        public int Skip { get; set; }
        [DataMember(Order = 2)]
        public int Take { get; set; }
    }
}
