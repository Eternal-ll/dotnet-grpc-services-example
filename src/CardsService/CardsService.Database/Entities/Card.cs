namespace CardsService.Database.Entities
{
    /// <summary>
    /// Карта
    /// </summary>
    public class Card : Base.Entity
    {
        /// <summary>
        /// Тип карты
        /// </summary>
        public int CardTypeId { get; set; }
        /// <summary>
        /// Серийный номер карты
        /// </summary>
        public string Sn { get; set; } = null!;
        public virtual CardType CardType { get; set; } = null!;
    }
}
