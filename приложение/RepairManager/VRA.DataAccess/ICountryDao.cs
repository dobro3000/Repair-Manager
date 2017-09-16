using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описания переменных и методов для таблицы Страны.
    /// </summary>
    public interface ICountryDao
    {
        /// <summary>
        /// Загружает страны.
        /// </summary>
        /// <returns></returns>
        List<Country> Load();
        /// <summary>
        /// Получет страну.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Country Get(int id);
        /// <summary>
        /// Добавляет страну.
        /// </summary>
        /// <param name="customer"></param>
        void Add(Country customer);
        /// <summary>
        /// Удаляет страну.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
