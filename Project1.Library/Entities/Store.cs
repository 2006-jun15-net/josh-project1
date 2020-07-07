using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    class Store
    {
        /// <summary>
        /// Unique Id for a store.
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// Name of store. Does not have to be Unique.
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// Address of store. Must be Unique. 
        /// </summary>
        public string StoreAddress { get; set; }
        
        //Dictionary<Product, int> StoreInventory { get; set; }

        /// <summary>
        /// Constructor for Store object from DB. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public Store(int id, string name, string address)
        {
            StoreId = id;
            StoreName = name;
            StoreAddress = address;
        }

        /// <summary>
        /// Constructor for new Store object created in the application. Id added when added to DB.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public Store(string name, string address)
        {
            StoreName = name;
            StoreAddress = address;
        }
    }
}
