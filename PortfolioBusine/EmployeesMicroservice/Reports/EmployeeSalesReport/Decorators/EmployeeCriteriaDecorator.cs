using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesMicroservice.ReportModels;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport.Decorators
{
    public class EmployeeCriteriaDecorator : EmployeeSalesReportDecorator
    {
        IEnumerable<int> _employeeIds;
        //constructor
        public EmployeeCriteriaDecorator(IEnumerable<int> employeeIds, IGetEmployeeSalesReportData reportData) : base(reportData)
        {
            _reportData = reportData;
            _employeeIds = employeeIds;
        }

        public override IEnumerable<IEmployeeSalesReportData> filterQuery()
        {
            if (_employeeIds != null)
            {
                filteredData = filteredData
                    .Where(x => _employeeIds.Contains(x.userID));
            }

            return filteredData;
        }
    }
}
