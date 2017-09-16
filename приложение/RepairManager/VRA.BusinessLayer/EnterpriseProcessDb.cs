using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public  class EnterpriseProcessDb : IEnterpriseProcess
    {
        private static IEnterpriseDao _enterpriseDao = new EnterpriseDao();

        public void Add(EnterpriseDto artist)
        {
            _enterpriseDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _enterpriseDao.Delete(id);
        }

        public IList<EnterpriseDto> GetList()
        {
            return DtoConvert.Convert(DaoFactory.GetEnterprisenDao().Load());
        }
    }
}
