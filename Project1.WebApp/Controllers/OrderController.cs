using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View();
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
