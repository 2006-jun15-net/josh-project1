using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project1.DataAccess.Model;
using Project1.DataAccess.Repositories;
using Project1.Library.Entities;
using Project1.WebApp.ViewModels;

namespace Project1.WebApp.Controllers
{
    public class OrderController : Controller
    {
        public OrderRepository Repo { get; }

        public OrderController(OrderRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()//Place new order
        {
            return View();
        }

        public ActionResult SelectProducts(int StoreId, int CustomerId)
        {
            var viewModel = new OrderViewModel { StoreId = StoreId, CustomerId = CustomerId};
            return View(viewModel);
        }

        // POST: OrderController/Create
        public ActionResult Checkout(int StoreId, int CustId, int prodID, int prodQty)
        {
            try
            {
                //Validate data entered.
                

                OrderEntity order = new OrderEntity
                {
                    OrderDate = DateTime.Now,
                    StoreId = StoreId,
                    CustomerId = CustId
                };

                Repo.InsertOrder(order, prodID, prodQty);

                return RedirectToAction(nameof(Create));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult CustDetails(int id)
        {
            OrderEntity order = (OrderEntity)Repo.GetCustomerHistoryById(id);
            var viewModel = new OrderViewModel
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                StoreId = order.StoreId,
                CustomerId = order.CustomerId,
                Orders = order.Orders
            };
            return View(viewModel);
        }

        //GET: OrderController/DisplayCustOrders
        public ActionResult DisplayCustOrders()
        {
            IEnumerable<OrderEntity> custOrders = Repo.GetAll();
            IEnumerable<OrderViewModel> viewModels = custOrders.Select(x => new OrderViewModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                StoreId = x.StoreId,
                CustomerId = x.CustomerId
            });
            return View(viewModels);
        }
        //GET: OrderController/DisplayStoreOrders
        public ActionResult DisplayStoreOrders()
        {
            IEnumerable<OrderEntity> storeOrders = Repo.GetAll();
            IEnumerable<OrderViewModel> viewModels = storeOrders.Select(x => new OrderViewModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                StoreId = x.StoreId,
                CustomerId = x.CustomerId
            });
            return View(viewModels);
        }
    }
}
