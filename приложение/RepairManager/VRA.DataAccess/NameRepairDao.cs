using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит методы для получения информации о ремонте.
    /// </summary>
    public class NameRepairDao : BaseDao, INameRepairDao
    {
        /// <summary>
        /// Хранит информацию о ремонте.
        /// </summary>
        private static IDictionary<int, NameRepair> TypeRepairs;

        /// <summary>
        /// Загружает ремонты.
        /// </summary>
        /// <returns></returns>
        public IList<NameRepair> Load()
        {
            TypeRepairs = new Dictionary<int, NameRepair>();
            try
            {
                var typeRep = LoadInternal();
                foreach (var tp in typeRep)
                {
                    TypeRepairs.Add(tp.IDRepair, tp);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return TypeRepairs.Values.ToList();
        }

        /// <summary>
        /// Загружает ремонт.
        /// </summary>
        /// <returns></returns>
        public IList<NameRepair> LoadInternal()
        {
            IList<NameRepair> typeRep = new List<NameRepair>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT IDRepair, NameRepairs FROM TypeRepair";
                        cmd.CommandType = CommandType.Text;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                typeRep.Add(LoadNameRep(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return typeRep;
        }

        /// <summary>
        /// Получает информацию о текущем ремонте.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NameRepair Get(int id)
        {
            if (TypeRepairs == null)
                Load();
            return TypeRepairs.ContainsKey(id) ? TypeRepairs[id] : null;
        }

        /// <summary>
        /// Удаляет информацию о текущем ремонте.
        /// </summary>
        public void Reset()
        {
            if (TypeRepairs == null)
                return;
            TypeRepairs.Clear();
        }

        /// <summary>
        /// Загружает информацию о ремонте из текущей базы данных.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static NameRepair LoadNameRep(SqlDataReader reader)
        {
            NameRepair nation = new NameRepair();
            try
            {
                nation.IDRepair = reader.GetInt32(reader.GetOrdinal("IDRepair"));
                nation.NameTypeRepair = reader.GetString(reader.GetOrdinal("NameRepairs"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return nation;
        }
    }
}
