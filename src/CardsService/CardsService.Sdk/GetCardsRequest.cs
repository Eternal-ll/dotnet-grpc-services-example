using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    /// <summary>
    /// Запрос на получение списка карт
    /// </summary>
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
        /// <summary>
        /// Пропустить Х записей
        /// </summary>
        [DataMember(Order = 1)]
        public int Skip { get; set; }
        /// <summary>
        /// Запросить Х записей
        /// </summary>
        [DataMember(Order = 2)]
        public int Take { get; set; }
    }
}
