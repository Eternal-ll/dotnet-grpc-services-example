using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    /// <summary>
    /// Информация о карте
    /// </summary>
    [DataContract]
    public class Card
    {
        /// <summary>
        /// ИД
        /// </summary>
        [DataMember(Order = 1)]
        public int Id { get; set; }
        /// <summary>
        /// Тип карты
        /// </summary>
        [DataMember(Order = 2)]
        public CardType Type { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        [DataMember(Order = 3)]
        public string Sn { get; set; }
    }
}
