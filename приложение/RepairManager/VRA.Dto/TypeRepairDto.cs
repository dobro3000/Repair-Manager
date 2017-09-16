namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных таблицы Вид ремонта
    /// </summary>
    public class TypeRepairDto
    {
        /// <summary>
        /// Хранит данные о цене текущего ремонта.
        /// </summary>
        public double? Cost { get; set; }

        /// <summary>
        /// Хранит данные о примечаниях к текущему ремонту.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Хранит информацию о продолжительности текущего ремонта.
        /// </summary>
        public double? Lenght { get; set; }

        /// <summary>
        /// Хранит информацию о названии текущего ремонта.
        /// </summary>
        public string NameRepair { get; set; }

        /// <summary>
        /// Хранит информацию о ID ремонта.
        /// </summary>
        public int IDRepair { get; set; }
    }
}
