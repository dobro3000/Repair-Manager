namespace VRA.Dto
{
    /// <summary>
    /// Содержит описания переменных для создания графического отчета
    /// </summary>
    public class ReportItemDto
    {
        /// <summary>
        /// Содердит информацию о дате.
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Содержит информацию о количестве.
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// Содержит информацию о цене.
        /// </summary>
        public decimal price { get; set; }
    }
}
