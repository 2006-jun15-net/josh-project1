using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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

        public IEnumerable<OrderEntity> GetOrders()
        {
            IQueryable<Orders> orders = _dbContext.Orders;

            return orders.Select(o => new OrderEntity
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate
            });
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

        public OrderEntity GetStoreHistoryById(int id)
        {
            var storeOrders = _dbContext.OrderHistory
                .Include(o => o.Order)
                .First(o => o.StoreId == id);
            OrderEntity orderResults;
            return orderResults = new OrderEntity
            {
                OrderId = storeOrders.OrderId,
                OrderDate = storeOrders.Order.OrderDate,
                StoreId = storeOrders.StoreId,
                CustomerId = storeOrders.CustomerId,
                Orders = GetOrderContents(storeOrders.OrderId)
            };
        }

        public OrderEntity GetCustomerHistoryById(int id)
        {
            var custOrders = _dbContext.OrderHistory
                .Include(o => o.Order)
                .First(o => o.CustomerId == id);
            OrderEntity orderResults;
            return orderResults = new OrderEntity
            {
                OrderId = custOrders.OrderId,
                OrderDate = custOrders.Order.OrderDate,
                StoreId = custOrders.StoreId,
                CustomerId = custOrders.CustomerId,
                Orders = GetOrderContents(custOrders.OrderId)
            };
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

        public ProductEntity GetProduct(int prodId)
        {
            var product = _dbContext.Product
                .Find(prodId);

            return new ProductEntity
            {
                ProductId = product.ProductId,
                ProdDescription = product.ProductDescription,
                ProdPrice = (double)product.ProductPrice
            };

        }

        //insert
        public void InsertOrder(OrderEntity newOrder, int prodId, int qty)
        {
            try
            {
                var order = new Orders
                {
                    OrderDate = newOrder.OrderDate
                };

                _dbContext.Add(order);
                Save();

                var lastId = _dbContext.Orders.Max(item => item.OrderId);
                var orderHist = new OrderHistory
                {
                    StoreId = newOrder.StoreId,
                    CustomerId = newOrder.CustomerId,
                    OrderId = lastId,
                    ProductId = prodId,
                    Quantity = qty,
                    Customer = new Customer
                    {
                        CustomerId = newOrder.CustomerId
                    },
                    Store = new Store
                    {
                        StoreId = newOrder.StoreId
                    },
                    Order = new Orders
                    {
                        OrderId = lastId
                    }
                };
                _dbContext.OrderHistory.Add(orderHist);
                Save();
            }
            catch (Exception)
            {

            }
            
        }
        //save
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
