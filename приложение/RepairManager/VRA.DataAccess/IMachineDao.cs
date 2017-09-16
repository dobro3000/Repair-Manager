using System.Collections.Generic;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит описание методов и полей для работы с таблицей Станок.
    /// </summary>
    public interface IMachineDao
    {
        /// <summary>
        /// Получает станок.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Machine Get(int id);
        /// <summary>
        /// Получает все станки.
        /// </summary>
        /// <returns></returns>
        IList<Machine> GetAll();
        /// <summary>
        /// Добавляет станок.
        /// </summary>
        /// <param name="customer"></param>
        void Add(Machine customer);
        /// <summary>
        /// Обновляет станок.
        /// </summary>
        /// <param name="customer"></param>
        void Update(Machine customer);
        /// <summary>
        /// Удаляет станок.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// Ищет станок.
        /// </summary>
        /// <param name="codeMachine">Код станка.</param>
        /// <param name="nameEnterprise">Название предприятия.</param>
        /// <param name="nameCountry">Название страны.</param>
        /// <returns></returns>
        IList<Machine> SearchMachine(string codeMachine, string nameEnterprise, string nameCountry);
    }
}
