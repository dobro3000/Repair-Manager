using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IMachineProcess
    {
        IList<MachineDto> GetList();
 
        MachineDto Get(int id);

        void Add(MachineDto artist);
  
        void Update(MachineDto artist);
 
        void Delete(int id);

        IList<MachineDto> SearchMachine(string codeMachine, string nameEnterprise, string nameCountry);
    }
}
