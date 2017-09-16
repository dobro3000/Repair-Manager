using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит методя для работы с данными из таблицы Страна.
    /// </summary>
    public class CountryDao : BaseDao, ICountryDao
    {
        /// <summary>
        /// Хранит информацию о станах.
        /// </summary>
        private static IDictionary<int, Country> Countrys;

        /// <summary>
        /// Добавляет текущую страну.
        /// </summary>
        /// <param name="countr"></param>
        public void Add(Country countr)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Country(NameCountry) VALUES(@countr)";
                        cmd.Parameters.AddWithValue("@countr", countr.NameCountry);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Удаляет текущую страну.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Country WHERE IDCountry = @ID";
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Получает текущую страну.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Get(int id)
        {
            if (Countrys == null)
                Load();
            return Countrys.ContainsKey(id) ? Countrys[id] : null;
        }

        /// <summary>
        /// Очищает массив, хранящий информацию о странах.
        /// </summary>
        public void Reset()
        {
            if (Countrys == null)
                return;
            Countrys.Clear();
        }

        /// <summary>
        /// Загружает информацию о странах.
        /// </summary>
        /// <returns></returns>
        public List<Country> Load()
        {
            Countrys = new Dictionary<int, Country>();
            try
            {
                var countrys = LoadInternal();
                foreach (var countr in countrys)
                {
                    Countrys.Add(countr.IDCountry, countr);
                }
            }
            catch (Exception exc)
            {

                throw;
            }
            return Countrys.Values.ToList();
        }

        /// <summary>
        /// Загружает информацию о странах.
        /// </summary>
        /// <returns></returns>
        private IList<Country> LoadInternal()
        {
            IList<Country> nations = new List<Country>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT IDCountry, NameCountry FROM Country";
                        cmd.CommandType = CommandType.Text;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nations.Add(LoadCountry(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return nations;
        }

        /// <summary>
        /// Выгружает информацию о странах из текущей базы данных.
        /// </summary>
        /// <param name="reader">Строка подключения.</param>
        /// <returns>Полученная информацию из таблицы Страны.</returns>
        private static Country LoadCountry(SqlDataReader reader)
        {
            Country countr = new Country();
            try
            {
                countr.IDCountry = reader.GetInt32(reader.GetOrdinal("IDCountry"));
                countr.NameCountry = reader.GetString(reader.GetOrdinal("NameCountry"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return countr;
        }


    }
}
