using System.Collections.Generic;
using VRA.DataAccess;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class NameRepairProcessDb : INameRepairProcessDb
    {
        
        private static INameRepairDao repDao = new NameRepairDao();

        public IList<NameRepairDto> GetList()
        {
            return DtoConvert.Convert(DaoFactory.GetNameRepairDao().Load());
        }
    }
}
