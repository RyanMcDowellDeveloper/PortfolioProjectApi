using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesMicroservice.EFModels
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
