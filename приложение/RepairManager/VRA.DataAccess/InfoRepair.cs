using System;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит информацию о переменных для представления Информация о ремонте.
    /// </summary>
    public class InfoRepair
    {
        /// <summary>
        /// Название ремонта.
        /// </summary>
        public string NameRepairs { get; set; }

        /// <summary>
        /// Дата начала ремонта.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Цена ремонта.
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// Продолжительность ремонта.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Примечание к ремонту.
        /// </summary>
        public string Note { get; set; }
    }
}
