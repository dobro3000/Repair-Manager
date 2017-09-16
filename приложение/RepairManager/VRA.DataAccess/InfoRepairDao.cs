using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов для работы с представлением информация о ремонтах.
    /// </summary>
    public class InfoRepairDao : BaseDao, IInfoRepairDao
    {
        /// <summary>
        /// Загружает информацию о ремонтах.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static InfoRepair LoadInfo(SqlDataReader reader)
        {         
            InfoRepair infoRepair = new InfoRepair();

            try
            {
                infoRepair.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                infoRepair.NameRepairs = reader.GetString(reader.GetOrdinal("NameRepairs"));
                infoRepair.Note = reader.GetString(reader.GetOrdinal("Note"));

                object decease1 = reader["Cost"];
                if (decease1 != DBNull.Value)
                    infoRepair.Cost = Convert.ToInt32(decease1);

                object decease = reader["Length"];
                if (decease != DBNull.Value)
                    infoRepair.Length = Convert.ToInt32(decease);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return infoRepair;
        }

        /// <summary>
        /// Добавляет информацию о ремонте.
        /// </summary>
        /// <param name="infoRep"></param>
        public void Add(InfoRepair infoRep)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO InfoRepair(Cost, Length, NameRepairs, Note, StartDate) VALUES(@Cost, @Length, @NameRepairs, @Note, @StartDate)";
                        cmd.Parameters.AddWithValue("@Cost", infoRep.Cost);
                        cmd.Parameters.AddWithValue("@Length", infoRep.Length);
                        cmd.Parameters.AddWithValue("@NameRepairs", infoRep.NameRepairs);
                        cmd.Parameters.AddWithValue("@Note", infoRep.Note);
                        cmd.Parameters.AddWithValue("@StartDate", infoRep.StartDate);

                        //object decease = customer.Note.HasValue ? (object)customer.Note.Value : DBNull.Value;
                        //cmd.Parameters.AddWithValue("@Note", decease);

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
        /// Удаляет информацию о ремонте.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM InfoRepair WHERE StartDate = @ID1";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Ошибка");
                    }
                }
            }
        }
        /// <summary>
        /// Получает информацию о ремонте.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InfoRepair Get(int id)
        {
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT Cost, Length, NameRepairs, Note, StartDate FROM InfoRepair WHERE StartDate = @ID1";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@ID1", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadInfo(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// Получает всю информацию о ремонте.
        /// </summary>
        /// <returns></returns>
        public IList<InfoRepair> GetAll()
        {
            IList<InfoRepair> repair = new List<InfoRepair>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Cost, Length, NameRepairs, Note, StartDate FROM InfoRepair";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                repair.Add(LoadInfo(dataReader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return repair;
        }

        /// <summary>
        /// Обновляет информацию о ремонте.
        /// </summary>
        /// <param name="customer"></param>
        public void Update(InfoRepair customer)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE InfoRepair SET  Cost = @Cost, Length = @Length, NameRepairs=@NameRepairs, Note=@Note, StartDate=@StartDate WHERE  StartDate = @ID1";
                        cmd.Parameters.AddWithValue("@ID1", customer.StartDate);

                        //object decease = customer.Note.HasValue ? (object)customer.Note.Value : DBNull.Value;
                        //cmd.Parameters.AddWithValue("@Note", decease);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
    }
}
