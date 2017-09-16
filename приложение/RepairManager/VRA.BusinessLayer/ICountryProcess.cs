using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface ICountryProcess
    {
        IList<CountryDto> GetList();
        
        void Add(CountryDto artist);
 
        void Delete(int id);
    }
}
