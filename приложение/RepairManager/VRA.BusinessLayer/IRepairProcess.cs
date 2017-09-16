using System;
using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IRepairProcess
    {
      
        IList<RepairDto> GetList();
 
        RepairDto Get(int id);
        
        void Add(RepairDto artist);
  
        void Update(RepairDto artist);
  
        void Delete(DateTime id, int id2);

        IList<RepairDto> SearchRepair(string codeMachine, string nameRep, string date);
    }
}
