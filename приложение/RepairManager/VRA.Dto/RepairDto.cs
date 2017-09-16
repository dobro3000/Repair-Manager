using System;

namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных для таблицы Ремонт.
    /// </summary>
    public class RepairDto
    {
        /// <summary>
        /// Хранит информаицю о дате начала текущего ремонта.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Хранит примечание к текущему ремонту.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Хранит информацию о коде текущего станка.
        /// </summary>
        public int CodeMachine { get; set; }

        /// <summary>
        /// Хранит информацию о текущего ремонте.
        /// </summary>
        public NameRepairDto IDRepair { get; set; }
    }
}
