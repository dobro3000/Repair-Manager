using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface ITypeRepairProcess
    {
        IList<TypeRepairDto> GetList();

        TypeRepairDto Get(int id);
 
        void Add(TypeRepairDto artist);

        void Update(TypeRepairDto artist);

        void Delete(int id);
    }
}
