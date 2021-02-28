using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.ReportModels.TotalSalesByEmployee
{
    public class TotalSalesByEmployeeParams : ITotalSalesByEmployeeParams
    {
        public decimal? minSalary { get; set; }
        public decimal? maxSalary { get; set; }
    }
}
