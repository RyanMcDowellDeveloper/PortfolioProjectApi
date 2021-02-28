using EmployeesMicroservice.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport.Decorators
{
    public abstract class EmployeeSalesReportDecorator : IGetEmployeeSalesReportData
    {
        protected IGetEmployeeSalesReportData _reportData;
        protected IEnumerable<IEmployeeSalesReportData> filteredData;

        //contructor
        public EmployeeSalesReportDecorator(IGetEmployeeSalesReportData reportData)
        {
            _reportData = reportData;
        }

        public IEnumerable<IEmployeeSalesReportData> Executequery()
        {
            filteredData = _reportData.Executequery();
            return filterQuery();
        }

        public abstract IEnumerable<IEmployeeSalesReportData> filterQuery();
    }
}
