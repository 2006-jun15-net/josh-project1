using Project1.Library.Entities;
using System;
using Xunit;

namespace Project1.Tests
{
    public class CustomerTests
    {
        CustomerEntity cust = new CustomerEntity();
        [Fact]
        public void CustomerStoresFirstName()
        {
            //act
            string firstName = "Josh";

            //arrange
            cust.FirstName = firstName;

            //assert
            Assert.Equal(firstName, cust.FirstName);
        }

        [Fact]
        public void CustomerStoresLastName()
        {
            //act
            string lastName = "Bertrand";

            //arrange
            cust.LastName = lastName;

            //assert
            Assert.Equal(lastName, cust.LastName);
        }

        [Fact]
        public void CustomerStoresUserName()
        {
            //act
            string userName = "JBertrand";

            //arrange
            cust.UserName = userName;

            //assert
            Assert.Equal(userName, cust.UserName);
        }
    }
}
