using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project1.Library.Entities;
using Project1.DataAccess.Model;
using Project0.DataAccess;

namespace Project1.DataAccess
{
    public class CustomerRepository
    {

        private readonly project1Context _dbContext;//This is the Customer in the Model folder

        public CustomerRepository(project1Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Delete(object id)
        {
            Customer entity = _dbContext.Customer.Find(id);
            _dbContext.Remove(entity);
            Save();
        }

        public IEnumerable<Customer> GetAll()
        {
            IQueryable<Customer> items = _dbContext.Customer
                .Include(c => c.CustomerId);

            return (IEnumerable<Customer>)items.Select(Mapper.MapDbEntryToCustomer);
        }

        public CustomerEntity GetById(object id)
        {

            return Mapper.MapDbEntryToCustomer(customer: _dbContext.Customer.Find(id));
        }

        public void Insert(CustomerEntity obj)
        {
            Customer entity = Mapper.MapCustomerToDbEntry(obj);
            _dbContext.Add(entity);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        //public void Update(Customer obj)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}