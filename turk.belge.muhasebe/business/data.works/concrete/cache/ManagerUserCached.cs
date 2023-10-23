using business.data.access.concrete.services;
using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using entity.abstraction;
using entity.concretes.identity;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.cache
{
    public interface IManagerUserCached : IManagerUser { }
    public class ManagerUserCached : IManagerUserCached
    {
        const string key = "list";
        private readonly IMemoryCache cache;
        IManagerUser manager;

        public ManagerUserCached(IMemoryCache cache, IManagerUser manager)
        {
            this.cache = cache;
            this.manager = manager;
        }

        public async Task<BusinessResult> Create(UserTable data)
        {
            return await manager.Create(data);
        }

        public async Task<BusinessResult> Delete(int data)
        {
            var result = await manager.Delete(data);
            if (result.IsSucceeded)
            {
                List<UserTable>? o = cache.Get<List<UserTable>>(key);
                if (o != null)
                {
                    o.Remove(o.First(x => x.Id == data));
                    cache.Set(key, o);
                }

            }
            return result;
        }

        public async Task<BusinessResult<List<UserTable>>> ReadAllAsNoTracing(Expression<Func<UserTable, bool>> filter = null)
        {

            //  if (cache.TryGetValue(key, out List<UserTable> cachedData))
            //   {
            //       return BusinessResult<List<UserTable>>.Success(cachedData);
            //   }

            var result = await manager.ReadAllAsNoTracing(filter);

            if (result.IsSucceeded)
            {
                cache.Set(key, result.Data);
            }

            return result;
        }


        public async Task<BusinessResult<UserTable>> ReadById(int id)
        {
            //  List<UserTable>? o = cache.Get<List<UserTable>>("readEntitiesForListing");
            // if (o != null) { return BusinessResult<UserTable>.Success(o.First(x => x.Id == id)); }
            return await manager.ReadById(id);

        }

        public async Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
           return await manager.ReadllForListing();
        }

        public async Task<BusinessResult<List<UserTable>>> readUsersWithFirmsAndRoles_forListing()
        {
            return await manager.readUsersWithFirmsAndRoles_forListing();
        }

        public async Task<BusinessResult<List<UserTable>>> readUsersWithFirms_forListing()
        {
            return await manager.readUsersWithFirmsAndRoles_forListing();
        }

        public async Task<BusinessResult<UserTable>> readUserWithFirmsAndRoles(int id)
        {
            return await manager.readUserWithFirmsAndRoles(id);
        }

        public async Task<BusinessResult> Update(UserTable data)
        {
            return await manager.Update(data);
        }

        async public Task<BusinessResult> Update(UserTable entity, UserTable unchanged)
        {
            return await manager.Update(entity, unchanged);
        }
    }
}
