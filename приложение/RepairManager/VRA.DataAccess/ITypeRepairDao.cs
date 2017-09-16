using System.Collections.Generic;

namespace VRA.DataAccess
{
    public interface ITypeRepairDao
    {
        TypeRepair Get(int id);
        IList<TypeRepair> GetAll();
        void Add(TypeRepair customer);
        void Update(TypeRepair customer);
        void Delete(int id);

    }
}
