using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    public class OrderEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate { get; set; }
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
        public Dictionary<ProductEntity, int> Orders { get; set; }


        public OrderEntity()
        {
            
        }

    }
}
