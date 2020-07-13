using Microsoft.EntityFrameworkCore;
using Project1.DataAccess.Model;
using Project1.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Project1.DataAccess.Repositories
{

    public class OrderRepository
    {

        private readonly project1Context _dbContext;

        public OrderRepository(project1Context dbContext) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            IQueryable<OrderHistory> orders = _dbContext.OrderHistory
                .Include(o => o.Order);

            return orders.Select(o => new OrderEntity
            {
                OrderId = o.OrderId,
                OrderDate = o.Order.OrderDate,
                StoreId = o.StoreId,
                CustomerId = o.CustomerId
            });
        }

        public IEnumerable<OrderEntity> GetStoreHistoryById(int id)
        {
            var storeOrders = _dbContext.OrderHistory
                .Include(o => o.Order);

            return storeOrders.Select(s => new OrderEntity
            {
                OrderId = s.OrderId,
                OrderDate = s.Order.OrderDate,
                StoreId = s.StoreId,
                CustomerId = s.CustomerId,
                Orders = GetOrderContents(s.OrderId)
            });
        }

        public IEnumerable<OrderEntity> GetCustomerHistoryById(int id)
        {
            var custOrders = _dbContext.OrderHistory
                .Include(o => o.Order);

            return custOrders.Select(s => new OrderEntity
            {
                OrderId = s.OrderId,
                OrderDate = s.Order.OrderDate,
                StoreId = s.StoreId,
                CustomerId = s.CustomerId,
                Orders = GetOrderContents(s.OrderId)
            });
        }

        private Dictionary<ProductEntity, int> GetOrderContents(int id)
        {
            var orders = _dbContext.Orders
                .Include(o => o.OrderHistory)
                .First(o => o.OrderId == id);
            Dictionary<ProductEntity, int> cart = new Dictionary<ProductEntity, int>();
            foreach (var item in orders.OrderHistory)
            {
                var product = _dbContext.Product.Find(item.ProductId);
                ProductEntity prod = new ProductEntity
                {
                    ProductId = product.ProductId,
                    ProdDescription = product.ProductDescription,
                    ProdPrice = (double)product.ProductPrice
                };

                cart.Add(prod, item.Quantity);
            }

            return cart;

        }

        //insert
        public void InsertOrder()
        {

        }
        //save
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
