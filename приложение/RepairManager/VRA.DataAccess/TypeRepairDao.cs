using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описания методов для работы с данными из таблицы Вид ремонта.
    /// </summary>
    public class TypeRepairDao : BaseDao, ITypeRepairDao
    {
        /// <summary>
        /// Загружает вид ремонта.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static TypeRepair LoadRepair(SqlDataReader reader)
        {       
            TypeRepair typeRepair = new TypeRepair();

            try
            {
                typeRepair.Note = reader.GetString(reader.GetOrdinal("Note"));
                typeRepair.NameRepair = reader.GetString(reader.GetOrdinal("NameRepairs"));
                typeRepair.IDRepair = reader.GetInt32(reader.GetOrdinal("IDRepair"));
                object decease1 = reader["Length"];
                if (decease1 != DBNull.Value)
                    typeRepair.Lenght = Convert.ToDouble(decease1);

                object decease2 = reader["Cost"];
                if (decease2 != DBNull.Value)
                    typeRepair.Cost = Convert.ToDouble(decease2);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return typeRepair;
        }

        /// <summary>
        /// Добавляет текущий вид ремонта.
        /// </summary>
        /// <param name="typeRepair"></param>
        public void Add(TypeRepair typeRepair)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO TypeRepair(Note, NameRepairs, Length, Cost) VALUES(@Note, @NameRepair, @Lenght, @Cost)";
                        cmd.Parameters.AddWithValue("@Note", typeRepair.Note);
                        cmd.Parameters.AddWithValue("@NameRepair", typeRepair.NameRepair);

                        object decease1 = typeRepair.Lenght.HasValue ? (object)typeRepair.Lenght.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Lenght", decease1);

                        object decease2 = typeRepair.Cost.HasValue ? (object)typeRepair.Cost.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Cost", decease2);

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
        /// Удаляет текущий вид ремонта.
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
                        cmd.CommandText = "DELETE FROM TypeRepair WHERE IDRepair = @ID1";
                        cmd.Parameters.AddWithValue("@ID1", id);
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
        /// Получает текущий вид ремонта.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeRepair Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Note, NameRepairs, IDRepair, Length, Cost FROM TypeRepair WHERE IDRepair = @ID1 ";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadRepair(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// Получает все виды ремонта.
        /// </summary>
        /// <returns></returns>
        public IList<TypeRepair> GetAll()
        {
            IList<TypeRepair> machine = new List<TypeRepair>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Note, NameRepairs, IDRepair, Length, Cost FROM TypeRepair";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadRepair(dataReader));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return machine;
        }

        /// <summary>
        /// Обновляет текущий вид ремонта.
        /// </summary>
        /// <param name="typeRepair"></param>
        public void Update(TypeRepair typeRepair)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE TypeRepair SET  Note = @Note, NameRepairs = @NameRepairs,  Length=@Length, Cost=@Cost WHERE  IDRepair = @ID1";
                        cmd.Parameters.AddWithValue("@Note", typeRepair.Note);
                        cmd.Parameters.AddWithValue("@NameRepairs", typeRepair.NameRepair);
                        cmd.Parameters.AddWithValue("@ID1", typeRepair.IDRepair);

                        object decease1 = typeRepair.Lenght.HasValue ? (object)typeRepair.Lenght.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Length", decease1);

                        object decease2 = typeRepair.Cost.HasValue ? (object)typeRepair.Cost.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@Cost", decease2);
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
