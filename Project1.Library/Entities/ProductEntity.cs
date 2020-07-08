using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Library.Entities
{
    /// <summary>
    /// Product object.
    /// </summary>
    public class ProductEntity
    {
        /// <summary>
        /// Unique Id of product created when added to DB.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Name or description of product.
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// Price of product.
        /// </summary>
        public double ProductPrice {get; set;}

        /// <summary>
        /// Constructor for product pulled from DB.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public ProductEntity(int id, string description, double price)
        {
            ProductId = id;
            ProductDescription = description;
            ProductPrice = price;
        }

        /// <summary>
        /// Constructor for product created in Application. Id assigned when inserted into the DB.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public ProductEntity(string description, double price)
        {
            ProductDescription = description;
            ProductPrice = price;
        }

    }
}
