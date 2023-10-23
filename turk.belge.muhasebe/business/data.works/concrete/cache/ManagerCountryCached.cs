using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using entity.abstraction;
using entity.concretes.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.cache
{
    public interface IManagerCountryCached : IManagerCountry { }
    public class ManagerCountryCached : IManagerCountryCached
    {
        IManagerCountry manager;

        public ManagerCountryCached(IManagerCountry manager)
        {
            this.manager = manager;
        }

        public async Task<BusinessResult> Create(Country data)
        {
            return await manager.Create(data);
        }

        public async Task<BusinessResult> Delete(int data)
        {
            return await manager.Delete(data);
        }

        public async Task<BusinessResult<List<Country>>> ReadAllAsNoTracing(Expression<Func<Country, bool>> filter = null)
        {
            return await manager.ReadAllAsNoTracing(filter);
        }

        public async Task<BusinessResult<Country>> ReadById(int id)
        {
            return await manager.ReadById(id);
        }

        public async Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
            return await manager.ReadllForListing();
        }

        public async Task<BusinessResult> Update(Country entity, Country unchanged)
        {
            return await manager.Update(entity, unchanged);
        }

        public async Task<BusinessResult> Update(Country entity)
        {
            return await manager.Update(entity);
        }
    }
}
