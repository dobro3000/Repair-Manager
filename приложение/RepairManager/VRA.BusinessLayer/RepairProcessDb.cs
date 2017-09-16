using System;
using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class RepairProcessDb : IRepairProcess
    {
        private readonly IRepairDao _repairDao;

        public RepairProcessDb()
        {
            _repairDao = DaoFactory.GetRepairDao();
        }

        public void Add(RepairDto artist)
        {
            _repairDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(DateTime id, int id2)
        {
            _repairDao.Delete(id, id2);
        }

        public RepairDto Get(int id)
        {
            return DtoConvert.Convert(_repairDao.Get(id));
        }

        public IList<RepairDto> GetList()
        {
            return DtoConvert.Convert(_repairDao.GetAll());
        }

        public void Update(RepairDto artist)
        {
            _repairDao.Update(DtoConvert.Convert(artist));
        }

        public IList<RepairDto> SearchRepair(string codeMachine, string nameRep, string date)
        {
            return DtoConvert.Convert(_repairDao.SearchRepair(codeMachine, nameRep, date));
        }
    }
}
