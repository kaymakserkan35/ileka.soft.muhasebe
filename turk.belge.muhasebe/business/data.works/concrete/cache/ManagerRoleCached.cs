using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using entity.abstraction;
using entity.concretes.identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.cache
{
    public interface IManagerRoleCache : IManagerRole { }
    public class ManagerRoleCached : IManagerRoleCache
    {

        private readonly IMemoryCache cache;
        IManagerRole manager;

        public ManagerRoleCached(IMemoryCache cache, IManagerRole manager)
        {
            this.cache = cache;
            this.manager = manager;
        }

        public async Task<BusinessResult> Create(RoleTable data)
        {
            return await manager.Create(data);
        }

        public async Task<BusinessResult> Delete(int data)
        {
            return await manager.Delete(data);
        }

        public async Task<BusinessResult<List<RoleTable>>> ReadAllAsNoTracing(Expression<Func<RoleTable, bool>> filter = null)
        {
            return await manager.ReadAllAsNoTracing(filter);
        }

        public async Task<BusinessResult<RoleTable>> ReadById(int id)
        {
            return await manager.ReadById(id);
        }

        public async Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
           return await manager.ReadllForListing();
        }

        public async Task<BusinessResult> Update(RoleTable data)
        {
            return await manager.Update(data);
        }

        public async Task<BusinessResult> Update(RoleTable entity, RoleTable unchanged)
        {
          return await manager.Update(entity, unchanged);
        }
    }
}
