using System;
using System.Runtime.Serialization;

namespace ApplicationsService.Sdk
{
    /// <summary>
    /// Заявитель
    /// </summary>
    [DataContract]
    public class Applicant
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        /// <example>Иванов</example>
        [DataMember(Order = 1)]
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        /// <example>Иван</example>
        [DataMember(Order = 2)]
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        /// <example>Иванович</example>
        [DataMember(Order = 3)]
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        /// <example>2000-01-01</example>
        [DataMember(Order = 4)]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Номер СНИЛС
        /// </summary>
        [DataMember(Order = 5)]
        public string Snils { get; set; }
        /// <summary>
        /// Адрес проживания
        /// </summary>
        /// <example>г. Уфа, ул. Цюрупы, д. 10</example>
        [DataMember(Order = 6)]
        public ApplicantAddress LivingAddress { get; set; }
    }
}
