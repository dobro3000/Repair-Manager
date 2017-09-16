using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class MachineProcessDb : IMachineProcess
    {
        private readonly IMachineDao _machineDao;

        public MachineProcessDb()
        {
            _machineDao = DaoFactory.GeMachineDao();
        }

        public void Add(MachineDto artist)
        {
            _machineDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _machineDao.Delete(id);
        }

        public MachineDto Get(int id)
        {
            return DtoConvert.Convert(_machineDao.Get(id));
        }

        public IList<MachineDto> GetList()
        {
            return DtoConvert.Convert(_machineDao.GetAll());
        }

        public void Update(MachineDto artist)
        {
            _machineDao.Update(DtoConvert.Convert(artist));
        }

        public IList<MachineDto> SearchMachine(string codeMachine, string nameEnterprise, string nameCountry)
        {
            return DtoConvert.Convert(_machineDao.SearchMachine(codeMachine, nameEnterprise, nameCountry));
        }
    }
}
