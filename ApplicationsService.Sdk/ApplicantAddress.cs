using System;
using System.Runtime.Serialization;

namespace ApplicationsService.Sdk
{
    /// <summary>
    /// Адрес заявителя
    /// </summary>
    [DataContract]
    public class ApplicantAddress
    {
        /// <summary>
        /// Адрес
        /// </summary>
        [DataMember(Order = 1)]
        public string Address { get; set; }
        /// <summary>
        /// GUID ФИАС
        /// </summary>
        [DataMember(Order = 2)]
        public Guid FiasGuid { get; set; }
    }
}
