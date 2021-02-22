using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesMicroservice.EFModels
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
