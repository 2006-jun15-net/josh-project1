﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// Constructor for a customer from the DB. Includes all fields
        /// </summary>
        /// <param name="id"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="user"></param>
        public Customer(int id, string first, string last, string user)
        {
            CustomerId = id;
            FirstName = first;
            LastName = last;
            UserName = user;
        }

        /// <summary>
        /// Constructor for a customer created in the web app. Id is set when added to the DB.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="user"></param>
        public Customer(string first, string last, string user)
        {
            FirstName = first;
            LastName = last;
            UserName = user;
        }
        
    }
}