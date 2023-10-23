using entity.concretes.entities;
using manager.data.works.concrete.cache;
using service.Dtos.FirmDto;
using service.Dtos.ListingDtos;
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
    public class DeveloperFirmService : IDeveloperFirmService
    {
        IEntityDtoMapper mapper;
        IManagerFirmCached firmManager;
        IManagerModuleCached moduleManager;

        public DeveloperFirmService(IManagerFirmCached managerFirm, IEntityDtoMapper mapper, IManagerModuleCached moduleManager)
        {
            this.mapper = mapper;
            this.moduleManager = moduleManager;
            this.firmManager = managerFirm;
        }

        public Task<ServiceResult> AddFirm(FirmEditingDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<FirmEditingDto>> AddFirm()
        {
            var res = await moduleManager.ReadllForListing();
            if (!res.IsSucceeded) return ServiceResult<FirmEditingDto>.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());

            var dto = new FirmEditingDto() { Modulles = res.Data.Select(x => new ModuleListing_basicDto { Id = x.Id, Name = x.Name, IsSelected = false }).ToList() };
            return ServiceResult<FirmEditingDto>.Success(dto);


        }

        public async Task<ServiceResult> deleteFirm(int id)
        {
            var res = await firmManager.Delete(id);
            if (res.IsSucceeded) return ServiceResult.Success();
            return ServiceResult.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
        }

        public async Task<ServiceResult<List<FirmDto>>> ListFirm()
        {
            var res = await firmManager.readFirmsWithModulesAndOwner();
            if (res.IsSucceeded) return ServiceResult<List<FirmDto>>.Success(mapper.Map<FirmDto>(res.Data));
            return ServiceResult<List<FirmDto>>.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
        }

        public async Task<ServiceResult<FirmEditingDto>> UpdateFirm(int id)
        {
            var res = await firmManager.readFirmWithModules(id);
            if (!res.IsSucceeded) return ServiceResult<FirmEditingDto>.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
            var res_modules = await moduleManager.ReadAllAsNoTracing();
            if (!res_modules.IsSucceeded) return ServiceResult<FirmEditingDto>.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());

            var ent = res.Data;
            var modules = res_modules.Data;

            var dto = mapper.Map<FirmEditingDto>(ent);
            dto.Modulles.ForEach(x => x.IsSelected = true);
            foreach (var item in modules)
            {
                if (!ent.Modules.Any(x => x.Id.Equals(item.Id)))
                {
                    dto.Modulles.Add(new Dtos.ListingDtos.ModuleListing_basicDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        IsSelected = false
                    });
                }
            }
            return ServiceResult<FirmEditingDto>.Success(dto);
        }

        public async Task<ServiceResult> UpdateFirm(FirmEditingDto dto)
        {
            var ent = mapper.Map<Firm>(dto);
            ent.Modules = dto.SelectedModules.Select(x => new Module { Id = x }).ToList();
            var res = await firmManager.Update(ent);
            if (res.IsSucceeded) return ServiceResult.Success();
            return ServiceResult.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
        }
    }
}
