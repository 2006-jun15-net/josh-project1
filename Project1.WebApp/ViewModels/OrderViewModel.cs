using Project1.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public Dictionary<ProductEntity, int> Orders { get; set; }
    }
}
