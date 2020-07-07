using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Model
{
    public partial class Orders
    {
        public Orders()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
