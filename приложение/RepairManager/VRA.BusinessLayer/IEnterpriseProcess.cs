using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IEnterpriseProcess
    {
        
        IList<EnterpriseDto> GetList();
   
        void Add(EnterpriseDto artist);
   
        void Delete(int id);
    }
}
