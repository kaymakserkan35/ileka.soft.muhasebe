using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity.abstraction;
using entity.concretes.entities;
using manager.data.works.concrete.managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.cache
{
    public interface IManagerModuleCached : IManagerModule { }
    public class ManagerModuleCached : IManagerModuleCached
    {

        IManagerModule manager;

        public ManagerModuleCached(IManagerModule manager)
        {
            this.manager = manager;
        }

        public async Task<BusinessResult> Create(Module data)
        {
          return await manager.Create(data);
        }

        public async Task<BusinessResult> Delete(int data)
        {
           return await manager.Delete(data);
        }

        public async Task<BusinessResult<List<Module>>> ReadAllAsNoTracing(Expression<Func<Module, bool>> filter = null)
        {
           return await manager.ReadAllAsNoTracing(filter);
        }

        public async Task<BusinessResult<Module>> ReadById(int id)
        {
            return await manager.ReadById(id);
        }

        public async Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
            return await manager.ReadllForListing();
        }

        public async Task<BusinessResult> Update(Module entity, Module unchanged)
        {
            return await manager.Update(entity, unchanged); 
        }

        public async Task<BusinessResult> Update(Module entity)
        {
            return await manager.Update(entity);
        }
    }
}
