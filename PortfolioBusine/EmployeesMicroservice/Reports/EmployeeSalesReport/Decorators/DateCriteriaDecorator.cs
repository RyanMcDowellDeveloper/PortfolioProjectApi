using EmployeesMicroservice.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport.Decorators
{
    public class DateCriteriaDecorator : EmployeeSalesReportDecorator
    {
        DateTime? _startDate;
        DateTime? _endDate;

        //constructor
        public DateCriteriaDecorator(DateTime? startDate, DateTime? endDate, IGetEmployeeSalesReportData reportData) : base(reportData)
        {
            _reportData = reportData;
            _startDate = startDate;
            _endDate = endDate;
        }

        public override IEnumerable<IEmployeeSalesReportData> filterQuery()
        {
            if (_startDate != null & _endDate != null)
            {
                //added to convert nullable DateTime? parameters to DateTime
                DateTime startDate = _startDate ?? DateTime.Now;
                DateTime endDate = _endDate ?? DateTime.Now;

                filteredData = filteredData
                    .Where(x => x.saleDate.Date >= startDate.Date && x.saleDate.Date <= endDate.Date);
            }

            return filteredData;
        }
    }
}
