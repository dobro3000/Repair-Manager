using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class TypeRepairProcessDb : ITypeRepairProcess
    {
        private readonly ITypeRepairDao _typeRepairDao;

        public TypeRepairProcessDb()
        {
            _typeRepairDao = DaoFactory.GetTypeRepairDao();
        }

        public void Add(TypeRepairDto artist)
        {
            _typeRepairDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _typeRepairDao.Delete(id);
        }

        public TypeRepairDto Get(int id)
        {
            return DtoConvert.Convert(_typeRepairDao.Get(id));
        }

        public IList<TypeRepairDto> GetList()
        {
            return DtoConvert.Convert(_typeRepairDao.GetAll());
        }

        public void Update(TypeRepairDto artist)
        {
            _typeRepairDao.Update(DtoConvert.Convert(artist));
        }


    }
}
