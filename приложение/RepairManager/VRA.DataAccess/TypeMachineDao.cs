using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов для работы с данными из таблицы Тип станка.
    /// </summary>
    public class TypeMachineDao : BaseDao, ITypeMachineDao
    {
        /// <summary>
        /// Загружает тип станка.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static TypeMachine LoadTypeMachine(SqlDataReader reader)
        {  
            TypeMachine typeMachine = new TypeMachine();
            try
            {
                typeMachine.CodeMachine = reader.GetInt32(reader.GetOrdinal("CodeMachine"));
                typeMachine.Mark = reader.GetString(reader.GetOrdinal("Mark"));
                typeMachine.YearOfIssue = reader.GetInt32(reader.GetOrdinal("YearOfIssue")); ;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return typeMachine;
        }

        /// <summary>
        /// Добавляет текущий тип станка.
        /// </summary>
        /// <param name="typeMachine"></param>
        public void Add(TypeMachine typeMachine)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO TypeMachine(CodeMachine, Mark, YearOfIssue) VALUES(@CodeMachine, @Mark, @YearOfIssue)";
                        cmd.Parameters.AddWithValue("@CodeMachine", typeMachine.CodeMachine);
                        cmd.Parameters.AddWithValue("@Mark", typeMachine.Mark);
                        cmd.Parameters.AddWithValue("@YearOfIssue", typeMachine.YearOfIssue);
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
        /// Удаляет текущий тип станка.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TypeMachine WHERE CodeMachine = @ID1";
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
        /// Получает текущий тип станка.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeMachine Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CodeMachine, Mark, YearOfIssue FROM TypeMachine WHERE CodeMachine = @ID1";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadTypeMachine(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// Получает все типы станков.
        /// </summary>
        /// <returns></returns>
        public IList<TypeMachine> GetAll()
        {
            IList<TypeMachine> repair = new List<TypeMachine>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT CodeMachine, Mark, YearOfIssue FROM TypeMachine";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                repair.Add(LoadTypeMachine(dataReader));
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
        /// Обновляет текущий тип станка.
        /// </summary>
        /// <param name="typeRepair"></param>
        public void Update(TypeMachine typeRepair)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE TypeMachine SET Mark = @Mark, YearOfIssue=@YearOfIssue WHERE  CodeMachine = @ID1";
                        cmd.Parameters.AddWithValue("@ID1", typeRepair.CodeMachine);
                        cmd.Parameters.AddWithValue("@Mark", typeRepair.Mark);
                        cmd.Parameters.AddWithValue("@YearOfIssue", typeRepair.YearOfIssue);
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
        /// Осуществляет поиск станка.
        /// </summary>
        /// <param name="codeMachine">Код станка</param>
        /// <param name="mark">Марка станка.</param>
        /// <returns></returns>
        public IList<TypeMachine> SearchTypeMachine(string codeMachine, string mark)
        {
            IList<TypeMachine> typeMach = new List<TypeMachine>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM TypeMachine WHERE codeMachine like @codeMachine AND mark like @mark";
                        cmd.Parameters.AddWithValue("@codeMachine", "%" + codeMachine + "%");
                        cmd.Parameters.AddWithValue("@mark", "%" + mark + "%");
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                typeMach.Add(LoadTypeMachine(dataReader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return typeMach;
        }

    }
}
