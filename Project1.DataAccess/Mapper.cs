using Project1.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Project1.Library.Entities;

namespace Project0.DataAccess
{
    /// <summary>
    /// Static Mapper object translates objects to entries in the database and entries in the database to objects
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps a Customer from the Database to a Customer object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerEntity MapDbEntryToCustomer(Customer customer)
        {
            //int Id;
            //string FirstName, LastName, UserName;
            return new CustomerEntity
            (
                customer.CustomerId,
                customer.FirstName,
                customer.LastName,
                customer.UserName
            );
        }

        /// <summary>
        /// Maps a Customer object to an entry in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer MapCustomerToDbEntry(CustomerEntity customer)
        {
            return new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                UserName = customer.UserName
            };
        }
        /// <summary>
        /// Maps a Store entry from the database to a StoreLocation object
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static StoreEntity MapDbEntryToStore(Store store)
        {
            return new StoreEntity
            (
                store.StoreId,
                store.StoreName,
                store.StoreAddress,
                store.StoreInventory.Select(MapInventoryToStore)
                                          .ToList() //also get the inventory for the store
             );
        }


        public static ProductEntity MapInventoryToStore(StoreInventory inventory, int id)
        {
            //Dictionary<string, int> inv = new Dictionary<string, int>
            //{
            //    { inventory.Product.ProductDescription, inventory.Quantity }
            //};
            
            return new ProductEntity
            (
                inventory.Product.ProductId,
                inventory.Product.ProductDescription,
                (double)inventory.Product.ProductPrice
            );
            
        }

        //public static Model.Store MapStoreLocationToDbEntry(Library.StoreLocation store)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Maps a Product database entry to a Product object
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductEntity MapDbEntrytoProduct(Product product)
        {
            //int prodId;
            //string prodDescription;
            //double prodPrice;
            return new ProductEntity
            (
                product.ProductId,
                product.ProductDescription,
                (double)product.ProductPrice
            );
            
        }

        
    }
}