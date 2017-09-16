using System;
using System.Collections.Generic;

namespace VRA.DataAccess
{
    /// <summary>
    /// Хранит описание методов и полей для работы с таблицей Ремонт.
    /// </summary>
    public interface IRepairDao
    {
        /// <summary>
        /// Получает ремонт.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Repair Get(int id);
        /// <summary>
        /// Получает все ремонты.
        /// </summary>
        /// <returns></returns>
        IList<Repair> GetAll();
        /// <summary>
        /// Добавляет ремонт.
        /// </summary>
        /// <param name="customer"></param>
        void Add(Repair customer);
        /// <summary>
        /// Обнавляет ремонт.
        /// </summary>
        /// <param name="customer"></param>
        void Update(Repair customer);
        /// <summary>
        /// Удаляет ремонт.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id2"></param>
        void Delete(DateTime id, int id2);
        /// <summary>
        /// Осуществляет поиск ремонта.
        /// </summary>
        /// <param name="codeMachine">Код станка.</param>
        /// <param name="nameRep">Название ремонта.</param>
        /// <param name="date">Дата начала ремонта.</param>
        /// <returns></returns>
        IList<Repair> SearchRepair(string codeMachine, string nameRep, string date);
    }
}
