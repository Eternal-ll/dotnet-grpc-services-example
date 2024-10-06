using System.Runtime.Serialization;

namespace ApplicationsService.Sdk
{
    /// <summary>
    /// Заявление
    /// </summary>
    [DataContract]
    public class Application
    {
        /// <summary>
        /// Номер заявления
        /// </summary>
        [DataMember(Order = 1)]
        public int Id { get; set; }
    }
}
