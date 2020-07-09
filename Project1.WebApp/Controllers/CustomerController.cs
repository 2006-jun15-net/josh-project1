using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.DataAccess;
using Project1.Library.Entities;
using Project1.WebApp.ViewModels;

namespace Project1.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerRepository Repo { get;}

        public CustomerController(CustomerRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: CustomerController
        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<CustomerEntity> customers = (IEnumerable<CustomerEntity>)Repo.GetAll(search);
            IEnumerable<CustomerViewModel> viewModels = customers.Select(x => new CustomerViewModel
            {
                Id = x.CustomerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName
            });
            return View(viewModels);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
