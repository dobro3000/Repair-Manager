namespace VRA.Dto
{
    /// <summary>
    /// Содержит описание переменных для таблицы Вид станка.
    /// </summary>
    public class TypeMachineDto
    {
        /// <summary>
        /// Хранит код станка.
        /// </summary>
        public int CodeMachine { get; set; }

        /// <summary>
        /// Хранит марку текущего станка.
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// Хранит год выпуска текущего станка.
        /// </summary>
        public int YearOfIssue { get; set; }
    }
}
