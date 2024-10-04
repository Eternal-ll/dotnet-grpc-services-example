namespace CardsService.Database.Entities
{
    /// <summary>
    /// Тип карты
    /// </summary>
    public class CardType : Base.Entity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = null!;

        public virtual List<Card> Cards { get; set; } = null!;
    }
}
