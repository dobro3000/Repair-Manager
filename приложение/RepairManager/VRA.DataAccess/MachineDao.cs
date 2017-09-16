using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов для работы с тадлицей Станок.
    /// </summary>
    public class MachineDao : BaseDao, IMachineDao
    {
        /// <summary>
        /// Загружает станак.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Machine LoadMachine(SqlDataReader reader)
        {         
            Machine machine = new Machine();

            try
            {
                machine.CodeMashine = reader.GetInt32(reader.GetOrdinal("CodeMachine"));

                object decease1 = reader["NumberOfRepairs"];
                if (decease1 != DBNull.Value)
                    machine.NumberOfRepair = Convert.ToInt32(decease1);

                object decease2 = reader["IDEnterprise"];
                if (decease2 != DBNull.Value)
                    machine.IDEnterprise = Convert.ToInt32(decease2);

                object decease3 = reader["IDCountry"];
                if (decease3 != DBNull.Value)
                    machine.IDCountry = Convert.ToInt32(decease3);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return machine;
        }

        /// <summary>
        /// Добавляет станок.
        /// </summary>
        /// <param name="machine"></param>
        public void Add(Machine machine)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Machine(CodeMachine, IDCountry, IDEnterprise, NumberOfRepairs) VALUES(@CodeMashine, @IDCountry, @IDEnterprise, @NumberOfRepair)";
                        cmd.Parameters.AddWithValue("@CodeMashine", machine.CodeMashine);
                        cmd.Parameters.AddWithValue("@IDCountry", machine.IDCountry);
                        cmd.Parameters.AddWithValue("@IDEnterprise", machine.IDEnterprise);

                        object decease2 = machine.NumberOfRepair.HasValue ? (object)machine.NumberOfRepair.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@NumberOfRepair", decease2);

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
        /// Удаляет станок.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Machine WHERE CodeMachine = @ID1";
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
        /// Получает текущий станок.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Machine Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CodeMachine, IDCountry, IDEnterprise, NumberOfRepairs FROM Machine WHERE CodeMachine = @ID1 ";
                    cmd.Parameters.AddWithValue("@ID1", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadMachine(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// Получает станки.
        /// </summary>
        /// <returns></returns>
        public IList<Machine> GetAll()
        {
            IList<Machine> machine = new List<Machine>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT CodeMachine, IDCountry, IDEnterprise, NumberOfRepairs FROM Machine";
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machine.Add(LoadMachine(dataReader));
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
        /// Обнавляет текущий станок.
        /// </summary>
        /// <param name="machine"></param>
        public void Update(Machine machine)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Machine SET  CodeMachine = @CodeMashine, IDCountry = @IDCountry, IDEnterprise=@IDEnterprise, NumberOfRepairs=@NumberOfRepair WHERE  CodeMachine = @ID1";
                        cmd.Parameters.AddWithValue("@ID1", machine.CodeMashine);
                        cmd.Parameters.AddWithValue("@IDEnterprise", machine.IDEnterprise);
                        cmd.Parameters.AddWithValue("@IDCountry", machine.IDCountry);
                        cmd.Parameters.AddWithValue("@CodeMashine", machine.CodeMashine);
                        object decease2 = machine.NumberOfRepair.HasValue ? (object)machine.NumberOfRepair.Value : DBNull.Value;
                        cmd.Parameters.AddWithValue("@NumberOfRepair", decease2);
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
        /// <param name="codeMachine">Код станка.</param>
        /// <param name="nameCountry">Название страны.</param>
        /// <param name="nameEnterprise">Название предприятия.</param>
        /// <returns></returns>
        public IList<Machine> SearchMachine(string codeMachine,  string nameCountry, string nameEnterprise)
        {
            IList<Machine> machins = new List<Machine>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Machine.NumberOfRepairs, CodeMachine, Machine.IDEnterprise, Machine.IDCountry FROM Machine JOIN Enterprise ON Machine.IDEnterprise = Enterprise.IDEnterprise JOIN Country ON Machine.IDCountry = Country.IDCountry WHERE CodeMachine like @codeMachine AND Enterprise.NameEnterprise like @nameEnterprise AND Country.NameCountry like @nameCountry";
                        cmd.Parameters.AddWithValue("@codeMachine", "%" + codeMachine + "%");
                        cmd.Parameters.AddWithValue("@nameEnterprise", "%" + nameEnterprise + "%");
                        cmd.Parameters.AddWithValue("@nameCountry", "%" + nameCountry + "%");
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                machins.Add(LoadMachine(dataReader));
                            }

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            return machins;
        }
    }
}
