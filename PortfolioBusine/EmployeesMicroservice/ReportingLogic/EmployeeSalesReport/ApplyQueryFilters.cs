using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesMicroservice.ReportModels;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport
{
    public class ApplyQueryFilters : IApplyQueryFilters
    {
        public IEnumerable<IEmployeeSalesReportData> filter(IEmployeeSalesReportParams _params, IEnumerable<IEmployeeSalesReportData> reportData)
        {
            var filteredData = reportData;

            if (_params.employeeId != null)
            {
                filteredData = filteredData
                    .Where(x => _params.employeeId.Contains(x.userID));
            }

            if (_params.startDate != null & _params.endDate != null)
            {
                //added to convert nullable DateTime? parameters to DateTime
                DateTime startDate = _params.startDate ?? DateTime.Now;
                DateTime endDate = _params.endDate ?? DateTime.Now;

                filteredData = filteredData
                    .Where(x => x.saleDate.Date >= startDate.Date && x.saleDate.Date <= endDate.Date);
            }

            return filteredData;
        }
    }
}
