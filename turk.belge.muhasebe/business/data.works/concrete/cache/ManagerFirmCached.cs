using business.data.works.concrete.abstractions.interfaces;

using business.Response;
using entity.abstraction;
using entity.concretes.entities;

using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.cache
{

    public interface IManagerFirmCached : IManagerFirm { }
    public class ManagerFirmCached : IManagerFirmCached
    {
        private readonly IMemoryCache cache;
        IManagerFirm manager;

        public ManagerFirmCached(IManagerFirm manager, IMemoryCache cache)
        {
            this.manager = manager;
            this.cache = cache;
        }

        public async Task<BusinessResult> Create(Firm data)
        {
            return await manager.Create(data);
        }

        public async Task<BusinessResult> Delete(int data)
        {
            return await manager.Delete(data);
        }

        public async Task<BusinessResult<List<Firm>>> ReadAllAsNoTracing(Expression<Func<Firm, bool>> filter = null)
        {
            return await manager.ReadAllAsNoTracing(filter);
        }

        public async Task<BusinessResult<Firm>> ReadById(int id)
        {
            return await manager.ReadById(id);
        }

        public async Task<BusinessResult<List<Firm>>> readFirmsWithModules()
        {
            return await manager.readFirmsWithModules();
        }

        public async Task<BusinessResult<List<Firm>>> readFirmsWithModulesAndOwner()
        {
            return await manager.readFirmsWithModulesAndOwner();
        }

        public async Task<BusinessResult<Firm>> readFirmWithModules(int id)
        {
           return await manager.readFirmWithModules(id);
        }

        public Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
           return manager.ReadllForListing();
        }

        public async Task<BusinessResult> Update(Firm data)
        {
            return await manager.Update(data);
        }

        public Task<BusinessResult> Update(Firm entity, Firm unchanged)
        {
           return manager.Update(entity, unchanged);
        }
    }
}
