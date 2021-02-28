using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.Reports.TotalSalesByEmployee.Models
{
    public class TotalSalesByEmployeeModel : ITotalSalesByEmployee
    {
        public string employeeName { get; set; }
        public int salesCount { get; set; }
        public decimal? salesSum { get; set; }
    }
}
