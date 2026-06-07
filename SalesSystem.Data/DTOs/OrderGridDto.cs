using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.DTOs
{
    public class OrderGridDto
    {
        
            public int OrderId { get; set; }
            public string OrderedBy { get; set; }
            public string Product {  get; set; }
            public decimal Qantity { get; set; }
            public decimal UnitPrice { get; set; }
    }
}
