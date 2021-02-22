using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.ReportModels
{
    public class EmployeeSalesReportParams : IEmployeeSalesReportParams
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int[] employeeId { get; set; }
    }
}
