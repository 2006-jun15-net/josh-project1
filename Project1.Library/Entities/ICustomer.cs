using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    interface ICustomer
    {
        /// <summary>
        /// Unique Id of a customer. Generated in DB.
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Given name of customer. Can be non-unique
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Surname of customer. Can be non-unique
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User name selected by customer. Must be unique. Used for searching customers.
        /// </summary>
        public string UserName { get; set; }
    }
}
