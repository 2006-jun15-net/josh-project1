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

        //public void Insert(StoreEntity obj)
        //{

        //}

        //public void Delete(object id)
        //{

        //}

        public IEnumerable<StoreEntity> GetAll(string search)
        {
            IQueryable<Store> items = _dbContext.Store
                .Include(i => i.StoreInventory)
                .ThenInclude(p => p.Product);

            if(search != null)
            {
                items = items.Where(s => s.StoreName.Contains(search));
            }

            return (IEnumerable<StoreEntity>)items.Select(Mapper.MapDbEntryToStore);
        }

        public StoreEntity GetById(object id)
        {
            return Mapper.MapDbEntryToStore(_dbContext.Store.Find(id));
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
