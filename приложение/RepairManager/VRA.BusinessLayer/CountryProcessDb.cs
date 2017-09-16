using System.Collections.Generic;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public  class CountryProcessDb : ICountryProcess
    {
        private static ICountryDao _countryDao = new CountryDao();

        public void Add(CountryDto artist)
        {
            _countryDao.Add(DtoConvert.Convert(artist));
        }

        public void Delete(int id)
        {
            _countryDao.Delete(id);
        }

        public IList<CountryDto> GetList()
        {
            return DtoConvert.Convert(DaoFactory.GetCountryDao().Load());
        }
    }
}
