using EmployeesMicroservice.ReportModels;
using System.Collections.Generic;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport
{
    public interface IApplyQueryFilters
    {
        IEnumerable<IEmployeeSalesReportData> filter(IEmployeeSalesReportParams _params, IEnumerable<IEmployeeSalesReportData> reportData);
    }
}