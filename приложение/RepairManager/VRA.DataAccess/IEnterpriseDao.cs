using System.Collections.Generic;

namespace VRA.DataAccess
{
    /// <summary>
    /// Хранит описание методов и переменных для работы с таблицей Предприятия.
    /// </summary>
    public interface IEnterpriseDao
    {
        /// <summary>
        /// Получает предприятие.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Enterprise Get(int id);
        /// <summary>
        /// Загружает предприятия.
        /// </summary>
        /// <returns></returns>
        IList<Enterprise> Load();
        /// <summary>
        /// Добавляет предприятие.
        /// </summary>
        /// <param name="customer"></param>
        void Add(Enterprise customer);
        /// <summary>
        /// Удаляет предприятие.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
