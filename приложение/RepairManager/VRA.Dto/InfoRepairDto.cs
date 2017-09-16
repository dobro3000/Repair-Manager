using System;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных представления Информация о ремонте.
    /// </summary>
    public class InfoRepairDto
    {
        /// <summary>
        /// Хранит информацию о названии ремонта.
        /// </summary>
        public string NameRepairs { get; set; }

        /// <summary>
        /// Хранит информацию о дате начала ремонта.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Хранит информацию о цене ремонта.
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// Хранит информацию о продолжительности ремонта.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Хранит примечание к ремонту.
        /// </summary>
        public string Note { get; set; }
    }
}
