using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит методя для работы с данными из таблицы Предприятия.
    /// </summary>
    public class EnterpriseDao : BaseDao, IEnterpriseDao
    {
        /// <summary>
        /// Хранит информацию о предприятиях.
        /// </summary>
        private static IDictionary<int, Enterprise> Enterprises;

        /// <summary>
        /// Добавляет текущее предприятие.
        /// </summary>
        /// <param name="enterpr"></param>
        public void Add(Enterprise enterpr)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Enterprise(NameEnterprise) VALUES(@enterpr)";
                        cmd.Parameters.AddWithValue("@enterpr", enterpr.NameEnterprise);
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
        /// Удаляет текущее предприятие.
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
                        cmd.CommandText = "DELETE FROM Enterprise WHERE IDEnterprise = @ID";
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
        /// Получет текущее предприятие.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Enterprise Get(int id)
        {
            if (Enterprises == null)
                Load();
            return Enterprises.ContainsKey(id) ? Enterprises[id] : null;
        }

        /// <summary>
        /// Удаляет информацию о предприятиях.
        /// </summary>
        public void Reset()
        {
            if (Enterprises == null)
                return;
            Enterprises.Clear();
        }

        /// <summary>
        /// Загружает информацию о предприятиях.
        /// </summary>
        /// <returns></returns>
        public IList<Enterprise> Load()
        {
            Enterprises = new Dictionary<int, Enterprise>();
            try
            {
                var nations = LoadInternal();
                foreach (var nation in nations)
                {
                    Enterprises.Add(nation.IDEnterprise, nation);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return Enterprises.Values.ToList();
        }

        /// <summary>
        /// Загружает информацию о предприятиях.
        /// </summary>
        /// <returns></returns>
        private IList<Enterprise> LoadInternal()
        {
            IList<Enterprise> enterp = new List<Enterprise>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT IDEnterprise, NameEnterprise FROM Enterprise";
                        cmd.CommandType = CommandType.Text;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                enterp.Add(LoadEnterprise(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return enterp;
        }

        /// <summary>
        /// Получает информацию о предприятиях из текущей базы данных.
        /// </summary>
        /// <param name="reader">Строка подключаения.</param>
        /// <returns>Информация о предприятиях.</returns>
        private static Enterprise LoadEnterprise(SqlDataReader reader)
        {
            Enterprise enter = new Enterprise();
            try
            {
                enter.IDEnterprise = reader.GetInt32(reader.GetOrdinal("IDEnterprise"));
                enter.NameEnterprise = reader.GetString(reader.GetOrdinal("NameEnterprise"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return enter;
        }

    }
}
