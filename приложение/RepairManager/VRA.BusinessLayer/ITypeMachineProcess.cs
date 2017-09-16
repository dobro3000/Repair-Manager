using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public  interface ITypeMachineProcess
    {
     
        IList<TypeMachineDto> GetList();
        
        TypeMachineDto Get(int id);
        
        void Add(TypeMachineDto artist);
        
        void Update(TypeMachineDto artist);
 
        void Delete(int id);

        IList<TypeMachineDto> SearchTypeMachine(string codeMachine, string mark);
    }
}
