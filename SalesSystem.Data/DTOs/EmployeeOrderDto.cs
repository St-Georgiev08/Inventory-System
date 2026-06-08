using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.DTOs
{
    public class EmployeeOrderDto
    {
            public int OrderId { get; set; }

            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public int Quantity { get; set; }

            public decimal Price { get; set; }
     
    }
}
