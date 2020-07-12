using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    /// <summary>
    /// Store object.
    /// </summary>
    public class StoreEntity
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
        /// <summary>
        /// Dictionary of items and quantities the store has in stock
        /// </summary>
        public List<ProductEntity> StoreInventory { get; set; }

        /// <summary>
        /// Constructor for Store object from DB. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="inv"></param>
        public StoreEntity(int id, string name, string address, List<ProductEntity> inv)//Dictionary of Inventory must be added here.
        {
            StoreId = id;
            StoreName = name;
            StoreAddress = address;
            StoreInventory = inv;
        }

        /// <summary>
        /// Constructor for new Store object created in the application. Id added when added to DB.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public StoreEntity(int id, string name, string address)
        {
            StoreId = id;
            StoreName = name;
            StoreAddress = address;
        }
    }
}
