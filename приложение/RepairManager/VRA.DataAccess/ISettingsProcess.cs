namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов и полей для получения строки подключения.
    /// </summary>
    public  interface ISettingsProcess
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
