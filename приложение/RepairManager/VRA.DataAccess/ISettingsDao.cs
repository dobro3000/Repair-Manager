namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание полей и методов для подключения к базе.
    /// </summary>
    public interface ISettingsDao
    {
        /// <summary>
        /// Получает строку подключения.
        /// </summary>
        /// <returns></returns>
        string GetSettings();
        /// <summary>
        /// Устанавливает строку подключения.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="db"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SetSettings(string server, string db, string user, string password);
    }
}
