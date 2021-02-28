using EmployeesMicroservice.ReportModels;
using System.Collections.Generic;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport
{
    public interface IGetEmployeeSalesReportData
    {
        IEnumerable<IEmployeeSalesReportData> Executequery();
    }
}