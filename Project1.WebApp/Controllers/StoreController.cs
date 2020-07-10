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
    public class StoreController : Controller
    {
        public StoreRepository Repo { get; }

        public StoreController(StoreRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));


        // GET: StoreController
        public ActionResult Index([FromQuery] string search = "")
        {
            IEnumerable<StoreEntity> stores = (IEnumerable<StoreEntity>)Repo.GetAll(search);
            IEnumerable<StoreViewModel> viewModels = stores.Select(x => new StoreViewModel
            {
                Id = x.StoreId,
                StoreName = x.StoreName,
                StoreAddress = x.StoreAddress
            });
            return View(viewModels);
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
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

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
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

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
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
