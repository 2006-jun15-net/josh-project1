using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class OrderHistory
    {
        public int OrderHistId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
