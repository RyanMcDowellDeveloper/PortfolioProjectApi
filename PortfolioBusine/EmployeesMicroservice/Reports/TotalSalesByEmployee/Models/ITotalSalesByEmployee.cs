namespace EmployeesMicroservice.Reports.TotalSalesByEmployee.Models
{
    public interface ITotalSalesByEmployee
    {
        string employeeName { get; set; }
        int salesCount { get; set; }
        decimal? salesSum { get; set; }
    }
}