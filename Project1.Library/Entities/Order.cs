using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    class Order
    {
        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Product, int> Orders { get; set; }


        public Order(int orderid, int storeid, int custid)
        {
            OrderId = orderid;
            StoreId = storeid;
            CustomerId = custid;
        }

    }
}
