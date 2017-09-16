using System;
using VRA.Dto;
using System.Collections.ObjectModel;

namespace VRA.BusinessLayer
{
    public  interface IReportItemProcess
    {
        ObservableCollection<ReportItemDto> GetPurchased(string period, DateTime start, DateTime stop);
        ObservableCollection<ReportItemDto> GetSaled(string period, DateTime start, DateTime stop);
    }
}
