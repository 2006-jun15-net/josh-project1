using Project1.Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project1.Tests
{
    public class ProductTests
    {
        ProductEntity prod = new ProductEntity();
        [Fact]
        public void ProductStoresProductDescription()
        {
            //act
            string desc = "Sample Description";

            //arrange
            prod.ProdDescription = desc;

            //assert
            Assert.Equal(desc, prod.ProdDescription);

        }

        [Fact]
        public void ProductStoresProductPrice()
        {
            double price = 6.99;

            prod.ProdPrice = price;

            Assert.Equal(price, prod.ProdPrice);
        }
    }
}
