using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов для 
    /// </summary>
    public class ReportDao : BaseDao, IReportItemDao
    {
        private static Report LoadReport(SqlDataReader reader)
        {
            //Создаём пустой объект             
            Report report = new Report();
            //Заполняем поля объекта в соответствии с названиями полей результирующего             
            // набора данных             
            try
            {
                report.date = reader.GetDateTime(reader.GetOrdinal("mydate"));
            }
            catch (Exception ex)
            {
                report.date = DateTime.Now.Date;
            }
            report.price = reader.GetInt32(reader.GetOrdinal("mysum"));
            report.count = reader.GetInt32(reader.GetOrdinal("mycount"));

            return report;
        }

        public IList<Report> getPurchasedPerDays(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();

            //Получаем объект подключения к базе  
            using (var conn = GetConnection())
            {
                //Открываем соединение         
                conn.Open();
                //Создаем sql команду        
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды      
                    cmd.CommandText = "select CONVERT(date, StartDate, 105) as mydate, isnull(Sum(TypeRepair.Cost), 0.0) as mysum, ISNULL(count(TypeRepair.Cost), 0.0) as mycount from Repair JOIN TypeRepair ON Repair.IDRepair=TypeRepair.IDRepair  where StartDate between @start and @stop group by CONVERT(date, StartDate, 105)";
                    //Добавляем значение параметра    
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате            
                    // выполнения запроса данных                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }


        public IList<Report> getPurchasedPerMonth(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();

            //Получаем объект подключения к базе  
            using (var conn = GetConnection())
            {
                //Открываем соединение         
                conn.Open();
                //Создаем sql команду        
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды      
                    cmd.CommandText = "select CONVERT(date, StartDate, 105) as mydate, isnull(Sum(TypeRepair.Cost), 0.0) as mysum, ISNULL(count(TypeRepair.Cost), 0.0) as mycount from Repair JOIN TypeRepair ON Repair.IDRepair=TypeRepair.IDRepair between @start and @stop group by CONVERT(date, StartDate, 105)";
                    //Добавляем значение параметра    
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате            
                    // выполнения запроса данных                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }


        public IList<Report> getPurchasedPerYear(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();

            //Получаем объект подключения к базе  
            using (var conn = GetConnection())
            {
                //Открываем соединение         
                conn.Open();
                //Создаем sql команду        
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды      
                    cmd.CommandText = "select CONVERT(date, StartDate, 105) as mydate, isnull(Sum(TypeRepair.Cost), 0.0) as mysum, ISNULL(count(TypeRepair.Cost), 0.0)as mycount from Repair JOIN TypeRepair ON Repair.IDRepair=TypeRepair.IDRepair where DATEPART(Year, StartDate) between DATEPART(Year, @start) and DATEPART(Year, @stop) group by CONVERT(date, StartDate, 105) ";
                    //Добавляем значение параметра    
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате            
                    // выполнения запроса данных                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }

        public IList<Report> getSalesPerDay(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();

            //Получаем объект подключения к базе  
            using (var conn = GetConnection())
            {
                //Открываем соединение         
                conn.Open();
                //Создаем sql команду        
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды      
                    cmd.CommandText = "select CONVERT(date, StartDate, 105) as mydate, isnull(Sum(IDRepair), 0.0) as mysum, ISNULL(count(IDRepair), 0.0) as mycount from Repair where StartDate between @start and @stop group by CONVERT(date, StartDate, 105)";
                    //Добавляем значение параметра    
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате            
                    // выполнения запроса данных                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }

        public IList<Report> getSalesPerMonth(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();

            //Получаем объект подключения к базе  
            using (var conn = GetConnection())
            {
                //Открываем соединение         
                conn.Open();
                //Создаем sql команду        
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды      
                    cmd.CommandText = "select CONVERT(date, StartDate, 105) as mydate, isnull(Sum(IDRepair), 0.0) as mysum, ISNULL(count(IDRepair), 0.0) as mycount from Repair where StartDate between @start and @stop group by CONVERT(date, StartDate, 105)";
                    //Добавляем значение параметра    
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате            
                    // выполнения запроса данных                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }

        public IList<Report> getSalesPerYear(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();

            //Получаем объект подключения к базе  
            using (var conn = GetConnection())
            {
                //Открываем соединение         
                conn.Open();
                //Создаем sql команду        
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды      
                    cmd.CommandText = "select CONVERT(date, StartDate, 105) as mydate, isnull(Sum(IDRepair), 0.0) as mysum, ISNULL(count(IDRepair), 0.0) as mycount from Repair where DATEPART(Year, StartDate) between DATEPART(Year, @start) and DATEPART(Year, @stop) group by CONVERT(date, StartDate, 105)";
                    //Добавляем значение параметра    
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате            
                    // выполнения запроса данных                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }

    }
}
