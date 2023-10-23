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
    public interface IManagerDistrictCached : IManagerDistrict { }
    public class ManagerDistrictCached : IManagerDistrictCached
    {
        IManagerDistrict manager;

        public ManagerDistrictCached(IManagerDistrict manager)
        {
            this.manager = manager;
        }

        public async Task<BusinessResult> Create(District data)
        {
         return await manager.Create(data); 
        }

        public async Task<BusinessResult> Delete(int data)
        {
            return await manager.Delete(data);
        }

        public Task<BusinessResult<List<District>>> ReadAllAsNoTracing(Expression<Func<District, bool>> filter = null)
        {
            return manager.ReadAllAsNoTracing(filter);
        }

        public Task<BusinessResult<District>> ReadById(int id)
        {
            return manager.ReadById(id);
        }

        public async Task<BusinessResult<List<District>>> readDistrictsWİthCityAndCountry()
        {
            return await manager.readDistrictsWİthCityAndCountry();
        }

        public Task<BusinessResult<List<IEntity>>> ReadllForListing()
        {
           return manager.ReadllForListing();
        }

        public Task<BusinessResult> Update(District entity, District unchanged)
        {
            return manager.Update(entity, unchanged);
        }

        public async Task<BusinessResult> Update(District entity)
        {
            
            return await manager.Update(entity);
        }
    }
}
