using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project1.DataAccess.Repositories;
using Project1.DataAccess.Model;
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
            CustomerEntity customer = Repo.GetById(id);
            var viewModel = new CustomerViewModel
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                UserName = customer.UserName
            };
            return View(viewModel);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName", "LastName", "UserName")]CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FirstName, LastName, UserName;
                    CustomerEntity customer = new CustomerEntity
                    (
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        UserName = viewModel.UserName
                    ) ;
                        
                    Repo.Insert(customer);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
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
            //get cust by id
            CustomerEntity customer = Repo.GetById(id);
            var viewModel = new CustomerViewModel
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                UserName = customer.UserName
            };

            return View(viewModel);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                Repo.Delete(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
