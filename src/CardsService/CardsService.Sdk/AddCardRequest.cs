using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    /// <summary>
    /// Добавить карту
    /// </summary>
    [DataContract]
    public class AddCardRequest
    {
        /// <summary>
        /// Тип карты
        /// </summary>
        [DataMember(Order = 1)]
        public int CardTypeId { get; set; }
    }
}
