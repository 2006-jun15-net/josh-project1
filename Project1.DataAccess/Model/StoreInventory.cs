using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class StoreInventory
    {
        public int StoreInvId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
