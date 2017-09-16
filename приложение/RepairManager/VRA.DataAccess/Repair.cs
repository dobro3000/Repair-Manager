using System;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание переменных таблицы Ремонт.
    /// </summary>
    public class Repair
    {
        /// <summary>
        /// Хранит дату начала ремонта.
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// Хранит примечание ремонту.
        /// </summary>
        public string Note;
        /// <summary>
        /// Хранит код станка.
        /// </summary>
        public int CodeMachine;
        /// <summary>
        /// Хранит ID ремонта.
        /// </summary>
        public int IDRepair;
    }
}
