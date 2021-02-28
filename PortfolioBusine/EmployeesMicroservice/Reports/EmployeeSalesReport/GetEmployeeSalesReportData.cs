using EmployeesMicroservice.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesMicroservice.EFModels;
using EmployeesMicroservice.ReportingLogic.EmployeeSalesReport.Decorators;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport
{
    public class GetEmployeeSalesReportData
    {
        IEmployeeSalesReportParams _reportParams;

        //constructor
        public GetEmployeeSalesReportData(IEmployeeSalesReportParams reportParams)
        {
            _reportParams = reportParams;
        }

        public IEnumerable<IEmployeeSalesReportData> GetReportData()
        {
            IGetEmployeeSalesReportData reportBaseQuery = new EmployeeSalesReportBaseQuery();

            //var reportData = reportBaseQuery.Executequery();

            if(_reportParams.employeeId != null)
            {
                reportBaseQuery = new EmployeeCriteriaDecorator(_reportParams.employeeId, reportBaseQuery);
            }

            if(_reportParams.endDate !=null && _reportParams.startDate != null)
            {
                reportBaseQuery = new DateCriteriaDecorator(_reportParams.startDate, _reportParams.endDate, reportBaseQuery);
            }

            return reportBaseQuery.Executequery();
        }
    }
}

