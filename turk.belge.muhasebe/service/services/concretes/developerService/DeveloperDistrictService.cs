using manager.data.works.concrete.cache;
using service.Dtos.DistrictDto;
using service.Mapper;
using service.Response;
using service.services.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.services.concretes.developerService
{
    public class DeveloperDistrictService : IDeveloperDistrictService
    {
        IEntityDtoMapper mapper;
        IManagerDistrictCached manager;

        public DeveloperDistrictService(IManagerDistrictCached manager, IEntityDtoMapper mapper)
        {
            this.mapper= mapper;
            this.manager = manager;
        }

        public async Task<ServiceResult<List<DistrictDto>>> ListDistrict()
        {
            var res = await manager.readDistrictsWİthCityAndCountry();
            if (res.IsSucceeded) { return ServiceResult<List<DistrictDto>>.Success(mapper.Map<DistrictDto>(res.Data)); }
            return ServiceResult<List<DistrictDto>>.Fail(res.Errors.Select(x=>x.ErrorValue).ToArray());
        }

        public async Task<ServiceResult> deleteDistrict(int id)
        {
            var res = await manager.Delete(id);
            return ServiceResult.Success();
        }

        public async Task<ServiceResult> updateDistrict(DistrictDto dto)
        {
            var res = await manager.Update(new entity.concretes.entities.District
            {
                Id = dto.Id,
                CityId = dto.CityId,
                Name = dto.Name,
                PostalCode = dto.PostalCode
            });
            return ServiceResult.Success();
        }
    }
}
