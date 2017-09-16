using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class InfoRepairProcessDb : IInfoRepairProcessDb
    {
        private readonly IInfoRepairDao _infoRepairDao;

         public InfoRepairProcessDb()
        {  
            _infoRepairDao = DaoFactory.InfoRepairDao();
        }

        public void Add(InfoRepairDto artist)
        {
            _infoRepairDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _infoRepairDao.Delete(id);
        }

        public InfoRepairDto Get(int id)
        {
            return DtoConvert.Convert(_infoRepairDao.Get(id));
        }

        public IList<InfoRepairDto> GetList()
        {
            return DtoConvert.Convert(_infoRepairDao.GetAll());
        }

        public void Update(InfoRepairDto artist)
        {
            _infoRepairDao.Update(DtoConvert.Convert(artist));
        }
    }
}
