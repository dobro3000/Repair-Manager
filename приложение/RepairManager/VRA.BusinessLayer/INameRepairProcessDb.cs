using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface INameRepairProcessDb
    {
        IList<NameRepairDto> GetList();
    }
}
