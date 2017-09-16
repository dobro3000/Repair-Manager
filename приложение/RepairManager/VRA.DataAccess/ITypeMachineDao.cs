using System.Collections.Generic;

namespace VRA.DataAccess
{

    public interface ITypeMachineDao
    {
        TypeMachine Get(int id);
        IList<TypeMachine> GetAll();
        void Add(TypeMachine customer);
        void Update(TypeMachine customer);
        void Delete(int id);
        IList<TypeMachine> SearchTypeMachine(string codeMachine, string mark);
    }
}
