using System.Runtime.Serialization;

namespace ApplicationsService.Sdk
{
    /// <summary>
    /// Тип заявления
    /// </summary>
    [DataContract]
    public enum ApplicationType : int
    {
        /// <summary>
        /// Первичный выпуск карты
        /// </summary>
        CardIssue = 1,
        /// <summary>
        /// Перевыпуск карты
        /// </summary>
        CardReissue = 2
    }
}
