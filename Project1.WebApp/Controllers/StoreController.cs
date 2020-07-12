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
            StoreEntity store = Repo.GetById(id);
            var viewModel = new StoreViewModel
            {
                Id = store.StoreId,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                Inventory = store.StoreInventory
                
            };
            return View(viewModel);
        }
    }
}
