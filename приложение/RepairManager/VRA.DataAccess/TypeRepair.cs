namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание переменых таблицы Тип ремонта.
    /// </summary>
    public class TypeRepair
    {
        /// <summary>
        /// Хранит стоимость ремонта.
        /// </summary>
        public double? Cost;
        /// <summary>
        /// Хранит примечания к ремонту.
        /// </summary>
        public string Note;

        /// <summary>
        /// Хранит продолжительность ремонта.
        /// </summary>
        public double? Lenght;
        /// <summary>
        /// Хранит название ремонта.
        /// </summary>
        public string NameRepair;
        /// <summary>
        /// Хранит ID ремонта.
        /// </summary>
        public int IDRepair;
    }
}
