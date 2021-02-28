using EmployeesMicroservice.ReportModels.TotalSalesByEmployee;
using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using System.Collections.Generic;

namespace EmployeesMicroservice.Reports.TotalSalesByEmployee
{
    public interface IGetEmployeeTotalSales
    {
        IEnumerable<ITotalSalesByEmployee> GetData();
    }
}