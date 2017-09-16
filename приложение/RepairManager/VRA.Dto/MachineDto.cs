namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных для таблицы Станок.
    /// </summary>
    public class MachineDto
    {
        /// <summary>
        /// Хранит информацию о количестве ремонтов станка.
        /// </summary>
        public int? NumberOfRepair { get; set; }

        /// <summary>
        /// Хранит информацию о предприятии текущего станка.
        /// </summary>
        public EnterpriseDto IDEnterprise { get; set; }

        /// <summary>
        /// Хранит информацию о стране текущего станка.
        /// </summary>
        public CountryDto IDCountry { get; set; }

        /// <summary>
        /// Хранит информацию о коде текущего станка.
        /// </summary>
        public int CodeMashine { get; set; }
    }
}
