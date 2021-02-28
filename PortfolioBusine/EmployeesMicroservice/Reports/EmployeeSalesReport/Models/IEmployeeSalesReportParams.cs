using System;
using System.Collections.Generic;

namespace EmployeesMicroservice.ReportModels
{
    public interface IEmployeeSalesReportParams
    {
        int[] employeeId { get; set; }
        DateTime? endDate { get; set; }
        DateTime? startDate { get; set; }
    }
}