using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class Product
    {
        public Product()
        {
            OrderHistory = new HashSet<OrderHistory>();
            StoreInventory = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<StoreInventory> StoreInventory { get; set; }
    }
}
