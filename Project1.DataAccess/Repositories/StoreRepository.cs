using Microsoft.EntityFrameworkCore;
using Project0.DataAccess;
using Project1.DataAccess.Model;
using Project1.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.DataAccess.Repositories
{
    public class StoreRepository
    {
        private readonly project1Context _dbContext;

        public StoreRepository(project1Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<StoreEntity> GetAll(string search)
        {
            IQueryable<Store> stores = _dbContext.Store
                .Include(i => i.StoreInventory)
                .ThenInclude(p => p.Product);

            //if(search != null)
            //{
            //    stores = stores.Where(s => s.StoreName.Contains(search));
            //}
            return stores.Select(s => new StoreEntity {
                StoreId = s.StoreId,
                StoreName = s.StoreName,
                StoreAddress = s.StoreAddress
            });

            //return (IEnumerable<StoreEntity>)stores.Select(Mapper.MapDbEntryToStore);
        }

        public StoreEntity GetById(int id)
        {
            var store = _dbContext.Store.Find(id);

            return new StoreEntity
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                StoreInventory = GetStoreInventory(id)
            };
        }

        public Dictionary<ProductEntity, int> GetStoreInventory(int id)
        {
            var inv = _dbContext.Store
                .Include(i => i.StoreInventory)
                .First(i => i.StoreId == id);
            Dictionary<ProductEntity, int> inventory = new Dictionary<ProductEntity, int>();
            foreach(var item in inv.StoreInventory)
            {
                var product = _dbContext.Product.Find(item.ProductId);
                ProductEntity prod = new ProductEntity
                {
                    ProductId = product.ProductId,
                    ProdDescription = product.ProductDescription,
                    ProdPrice = (double)product.ProductPrice
                };
                inventory.Add(prod, item.Quantity);
            }
            return inventory;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
