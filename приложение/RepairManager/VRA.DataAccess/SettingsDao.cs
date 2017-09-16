using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// СОдержит описание методов для настройки подключения к текущей базе данных.
    /// </summary>
   public class SettingsDao : ISettingsDao
    {
        /// <summary>
        /// Получает строку подключения к текущей базе данных.
        /// </summary>
        /// <returns></returns>
        public string GetSettings()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["vradb"].ConnectionString;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Устанавливает параметры подключаения к текущей базе данных.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="db"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SetSettings(string server, string db, string user, string password)
        {
            SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder();
            conStr.DataSource = server;
            conStr.InitialCatalog = db;
            if (user == "")
            {
                conStr.IntegratedSecurity = true;
            }
            else
            {
                conStr.UserID = user;
                conStr.Password = password;
            }
            try
            {
                SqlConnection con = new SqlConnection(conStr.ConnectionString);
                con.Open();
            }
            catch
            {
                return false;
            }

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["vradb"].ConnectionString = conStr.ConnectionString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                config = ConfigurationManager.OpenExeConfiguration("VRA.Windows.exe");
                config.ConnectionStrings.ConnectionStrings["vradb"].ConnectionString = conStr.ConnectionString;
                config.Save(); ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return true;

        }
    }
}
