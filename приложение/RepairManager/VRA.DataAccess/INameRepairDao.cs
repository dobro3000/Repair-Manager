using System.Collections.Generic;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов и полей для работы с ремонтами.
    /// </summary>
    public interface INameRepairDao
    {
        /// <summary>
        /// Загружает ремонты.
        /// </summary>
        /// <returns></returns>
        IList<NameRepair> Load();
        /// <summary>
        /// Получает ремонт.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        NameRepair Get(int id);
    }
}
