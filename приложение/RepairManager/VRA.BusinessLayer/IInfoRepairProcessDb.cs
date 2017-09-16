using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IInfoRepairProcessDb
    {
        IList<InfoRepairDto> GetList();
 
        InfoRepairDto Get(int id);
        
        void Add(InfoRepairDto artist);
  
        void Update(InfoRepairDto artist);
  
        void Delete(int id);
    }
}
