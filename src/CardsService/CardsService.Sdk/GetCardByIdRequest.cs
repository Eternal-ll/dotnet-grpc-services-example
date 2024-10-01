using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    /// <summary>
    /// Получить информацию о карте по Ид
    /// </summary>
    [DataContract]
    public class GetCardByIdRequest
    {
        /// <summary>
        /// Ид
        /// </summary>
        [DataMember(Order = 1)]
        public int Id { get; set; }
    }
}
