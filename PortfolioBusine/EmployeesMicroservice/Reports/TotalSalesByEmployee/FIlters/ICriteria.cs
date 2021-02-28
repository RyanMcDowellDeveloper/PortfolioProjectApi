using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.Reports.TotalSalesByEmployee.FIlters
{
    interface ICriteria
    {
        IEnumerable<ITotalSalesByEmployee> meetCriteria(IEnumerable<ITotalSalesByEmployee> reportParams);
    }
}
