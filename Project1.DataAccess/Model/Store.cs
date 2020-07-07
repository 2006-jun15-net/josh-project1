using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class Store
    {
        public Store()
        {
            OrderHistory = new HashSet<OrderHistory>();
            StoreInventory = new HashSet<StoreInventory>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<StoreInventory> StoreInventory { get; set; }
    }
}
