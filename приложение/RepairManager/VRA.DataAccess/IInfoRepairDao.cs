using System.Collections.Generic;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов для работы с представлением Информаци о ремонте.
    /// </summary>
    public interface IInfoRepairDao
    {
        /// <summary>
        /// Получает данные.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InfoRepair Get(int id);
        /// <summary>
        /// Получакт все данные.
        /// </summary>
        /// <returns></returns>
        IList<InfoRepair> GetAll();
        /// <summary>
        /// Добавляет данные.
        /// </summary>
        /// <param name="customer"></param>
        void Add(InfoRepair customer);
        /// <summary>
        /// Обновляет данные.
        /// </summary>
        /// <param name="customer"></param>
        void Update(InfoRepair customer);
        /// <summary>
        /// Удаляет данные.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
