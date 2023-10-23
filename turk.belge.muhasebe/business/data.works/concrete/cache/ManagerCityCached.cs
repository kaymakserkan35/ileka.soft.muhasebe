using business.Response;
using entity.abstraction;
using entity.concretes.entities;
using business.data.works.concrete.abstractions.interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace manager.data.works.concrete.cache
{
    public interface IManagerCityCached : IManagerCity { }
    public class ManagerCityCached : IManagerCityCached
    {
        private readonly IMemoryCache cache;
        IManagerCity managerCity;

        public ManagerCityCached(IManagerCity managerCity, IMemoryCache cache)
        {
            this.cache = cache;
            this.managerCity = managerCity;
        }

        public async Task<BusinessResult> Create(City data)
        {
            return await managerCity.Create(data);
        }

        public async Task<BusinessResult> Delete(int data)
        {
            return await managerCity.Delete(data);
        }

        public async Task<BusinessResult<List<City>>> ReadAllAsNoTracing(Expression<Func<City, bool>> filter = null)
        {
            return await managerCity.ReadAllAsNoTracing(filter);
        }

        public async Task<BusinessResult<City>> ReadById(int id)
        {
            return await managerCity.ReadById(id);
        }

        public async Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
           return await managerCity.ReadllForListing();
        }

        public async Task<BusinessResult> Update(City data)
        {
           return await managerCity.Update(data);
        }

        public async Task<BusinessResult> Update(City entity, City unchanged)
        {
          return await managerCity.Update(entity, unchanged);
        }
    }
}
