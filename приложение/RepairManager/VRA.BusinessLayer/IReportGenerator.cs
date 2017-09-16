using System.Collections.Generic;
using System.IO;

namespace VRA.BusinessLayer
{
    public interface IReportGenerator
    {
        void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile);
        string genHtmlInfoRepairs(string rep);
    }

    
}
