namespace EmployeesMicroservice.ReportModels.TotalSalesByEmployee
{
    public interface ITotalSalesByEmployeeParams
    {
        decimal? maxSalary { get; set; }
        decimal? minSalary { get; set; }
    }
}