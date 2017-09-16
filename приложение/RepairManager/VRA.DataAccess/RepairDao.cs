using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов для работы с таблицей Ремонт.
    /// </summary>
    public class RepairDao : BaseDao, IRepairDao
    {
        /// <summary>
        /// Загружает ремонт.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Repair LoadRepair(SqlDataReader reader)
        {
            ////Создаём пустой объект            
            Repair repair = new Repair();
            try
            {
                repair.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                repair.CodeMachine = reader.GetInt32(reader.GetOrdinal("CodeMachine"));
                repair.IDRepair = reader.GetInt32(reader.GetOrdinal("IDRepair"));

                object decease2 = reader["Note"];
                if (decease2 != DBNull.Value)
                    repair.Note = Convert.ToString(decease2);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return repair;
        }

        /// <summary>
        /// Добавляет текущий ремонт.
        /// </summary>
        /// <param name="repair"></param>
        public void Add(Repair repair)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Repair(StartDate, Note, CodeMachine, IDRepair) VALUES(@StartDate, @Note, @CodeMachine, @IDRepair)";

                        cmd.Parameters.AddWithValue("@Note", repair.Note);
                        cmd.Parameters.AddWithValue("@CodeMachine", repair.CodeMachine);
                        cmd.Parameters.AddWithValue("@IDRepair", repair.IDRepair);

                        DateTime d = Convert.ToDateTime(repair.StartDate);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@StartDate", date);

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
        /// Удаляет текущий ремонт.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id2"></param>
        public void Delete(DateTime id, int id2)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Repair WHERE StartDate = @ID1 and CodeMachine = @ID2";

                        DateTime d = Convert.ToDateTime(id);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@ID1", date);
                        cmd.Parameters.AddWithValue("@ID2", id2);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Получает текущий ремонт.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Repair Get(int id)
        {
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT StartDate, Note, CodeMachine, IDRepair FROM Repair WHERE StartDate = @ID1,CodeMachine = @ID2, IDRepair = @ID3 ";

                    cmd.Parameters.AddWithValue("@ID1", id);
                    cmd.Parameters.AddWithValue("@ID2", id);
                    cmd.Parameters.AddWithValue("@ID3", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadRepair(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// Получает все ремонты.
        /// </summary>
        /// <returns></returns>
        public IList<Repair> GetAll()
        {
            IList<Repair> repair = new List<Repair>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT StartDate, Note, CodeMachine, IDRepair FROM Repair";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                repair.Add(LoadRepair(dataReader));
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
        /// Обновляет текущий ремонт.
        /// </summary>
        /// <param name="repair"></param>
        public void Update(Repair repair)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Repair SET StartDate = @StartDate, Note = @Note, CodeMachine=@CodeMachine, IDRepair=@IDRepair WHERE  StartDate = @ID1 and CodeMachine=@ID2";
                        cmd.Parameters.AddWithValue("@ID1", repair.StartDate);
                        cmd.Parameters.AddWithValue("@Note", repair.Note);
                        cmd.Parameters.AddWithValue("@ID2", repair.CodeMachine);
                        cmd.Parameters.AddWithValue("@IDRepair", repair.IDRepair);
                        cmd.Parameters.AddWithValue("@CodeMachine", repair.CodeMachine);
                        DateTime d = Convert.ToDateTime(repair.StartDate);
                        string date = d.ToString("yyyy-MM-dd 00:00:00.000");
                        cmd.Parameters.AddWithValue("@StartDate", date);

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
        /// Осуществляет поиск ремонта.
        /// </summary>
        /// <param name="codeMachine">Код станка.</param>
        /// <param name="nameRep">Название ремонта.</param>
        /// <param name="date">Дата начала ремонта.</param>
        /// <returns></returns>
        public IList<Repair> SearchRepair(string codeMachine, string nameRep, string date)
        {
            string d = "";
            if (date != "")
            {
                DateTime dd = Convert.ToDateTime(date);
                d = dd.ToString("yyyy-MM-dd");
            }
            IList<Repair> rep = new List<Repair>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Repair.IDRepair, StartDate, Repair.Note, CodeMachine, TypeRepair.NameRepairs FROM Repair JOIN TypeRepair on Repair.IDRepair = TypeRepair.IDRepair WHERE codeMachine like @codeMachine AND TypeRepair.NameRepairs like @nameRep AND StartDate like @d";
                        cmd.Parameters.AddWithValue("@codeMachine", "%" + codeMachine + "%");
                        cmd.Parameters.AddWithValue("@nameRep", "%" + nameRep + "%");
                        cmd.Parameters.AddWithValue("@d", d + "%");
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                rep.Add(LoadRepair(dataReader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return rep;
        }
        

    }
}
