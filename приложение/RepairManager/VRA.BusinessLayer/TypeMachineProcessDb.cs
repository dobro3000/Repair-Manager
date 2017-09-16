using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class TypeMachineProcessDb : ITypeMachineProcess
    {
        private readonly ITypeMachineDao _typeMachineDao;


        public TypeMachineProcessDb()
        {
            _typeMachineDao = DaoFactory.GetTypeMashineDao();
        }

        public void Add(TypeMachineDto artist)
        {
            _typeMachineDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _typeMachineDao.Delete(id);
        }

        public TypeMachineDto Get(int id)
        {
            return DtoConvert.Convert(_typeMachineDao.Get(id));
        }

        public IList<TypeMachineDto> GetList()
        {
            return DtoConvert.Convert(_typeMachineDao.GetAll());
        }

        public void Update(TypeMachineDto artist)
        {
            _typeMachineDao.Update(DtoConvert.Convert(artist));
        }

        public IList<TypeMachineDto> SearchTypeMachine(string codeMachine, string mark)
        {
            return DtoConvert.Convert(_typeMachineDao.SearchTypeMachine(codeMachine, mark));
        }
    }
}
