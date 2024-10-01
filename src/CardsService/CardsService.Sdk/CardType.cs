using System.Runtime.Serialization;

namespace CardsService.Sdk
{
    /// <summary>
    /// Тип карты
    /// </summary>
    [DataContract]
    public class CardType
    {
        /// <summary>
        /// Ид
        /// </summary>
        [DataMember(Order = 1)]
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
}
