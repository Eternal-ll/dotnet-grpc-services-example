using System.Runtime.Serialization;

namespace ApplicationsService.Sdk
{
    /// <summary>
    /// Подача заявления
    /// </summary>
    [DataContract]
    public class ApplicationSubmission
    {
        /// <summary>
        /// Тип заявления
        /// </summary>
        [DataMember(Order = 1)]
        public ApplicationType ApplicationType { get; set; }
        /// <summary>
        /// Тип карты
        /// </summary>
        [DataMember(Order = 2)]
        public int CardTypeId { get; set; }
        /// <summary>
        /// Данные заявителя
        /// </summary>
        [DataMember(Order = 3)]
        public Applicant Applicant { get; set; }
    }
}
