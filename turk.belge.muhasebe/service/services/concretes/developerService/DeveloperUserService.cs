using AutoMapper;
using entity.concretes.entities;
using entity.concretes.identity;
using manager.data.works.concrete.cache;
using Microsoft.Extensions.Logging;
using service.Dtos.ListingDtos;
using service.Dtos.UserDtos;
using service.Logger;
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
    public class DeveloperUserService : IDeveloperUserService
    {
        protected IManagerRoleCache managerRole;
        protected IManagerFirmCached managerFirm;
        protected IManagerUserCached managerUser;
        protected private IEntityDtoMapper mapper;
        protected IMyLogger<DeveloperService> logger;

        public DeveloperUserService(IManagerUserCached managerUser, IEntityDtoMapper mapper, IManagerFirmCached managerFirm, IManagerRoleCache managerRole, IMyLogger<DeveloperService> logger)
        {

            this.managerRole = managerRole;
            this.managerUser = managerUser;
            this.mapper = mapper;
            this.managerFirm = managerFirm;
            this.logger = logger;

        }


        #region User
        async public Task<ServiceResult<List<UserDto>>> ListUser()
        {

            var res = await managerUser.readUsersWithFirmsAndRoles_forListing();
            if (!res.IsSucceeded)
            {
                if (res.Errors == null)
                {
                    logger.LogError($"managerUser.readUsersWithFirmsAndRoles_forListing() methodundan hata geldi ancak hata nesnesi boş!", this);
                }

                return ServiceResult<List<UserDto>>.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());

            }

            var dto = mapper.Map<UserDto>(res.Data);


            return ServiceResult<List<UserDto>>.Success(dto);
        }


        async public Task<ServiceResult<UserEditingDto>> AddUser()
        {
            var res_firms = await managerFirm.ReadllForListing();
            var res_roles = await managerRole.ReadllForListing();

            if (!res_firms.IsSucceeded || !res_roles.IsSucceeded)
            {
                List<string> errMessages = new List<string>();
                if (!res_firms.IsSucceeded && res_firms.Errors == null) throw new Exception("");
                else
                {
                    errMessages = res_firms.Errors.Select(x => x.ErrorValue).ToList();
                }
                if (!res_roles.IsSucceeded && res_roles.Errors == null) throw new Exception("");
                else
                {
                    errMessages.AddRange(res_roles.Errors.Select(x => x.ErrorValue).ToList());
                }
                return ServiceResult<UserEditingDto>.Fail(errMessages.ToArray());
            }

            var dto_firms = res_firms.Data.Select(x => new FirmListing_BasicDto { Id = x.Id, Name = x.Name }).ToList();
            var dto_roles = res_roles.Data.Select(x => new RoleListing_basicDto { Id = x.Id, Name = x.Name }).ToList();

            UserEditingDto dto = new UserEditingDto()
            {
                Firms = dto_firms,
                Roles = dto_roles,
            };
            return ServiceResult<UserEditingDto>.Success(dto);

        }
        async public Task<ServiceResult> AddUser(UserEditingDto dto)
        {
            var model = mapper.Map<UserTable>(dto);
            model.Firms = dto.SelectedFirms.Select(x => new Firm { Id = x }).ToList();
            model.Roles = dto.SelectedRoles.Select(x => new RoleTable { Id = x }).ToList();
            var res = await managerUser.Create(model);
            if (!res.IsSucceeded) return ServiceResult.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
            return ServiceResult.Success();
        }

        async public Task<ServiceResult> deleteUser(int id)
        {
            var res = await managerUser.Delete(id);
            if (!res.IsSucceeded) return ServiceResult.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
            return ServiceResult.Success();
        }

        async public Task<ServiceResult<UserEditingDto>> UpdateUser(int id)
        {
            var res = await managerUser.readUserWithFirmsAndRoles(id);
            if (!res.IsSucceeded) return ServiceResult<UserEditingDto>.Fail(res.Errors.Select(x => x.ErrorValue).ToArray());
            var res_firms = await managerFirm.ReadllForListing();
            var res_roles = await managerRole.ReadllForListing();

            if (!res_firms.IsSucceeded || !res_roles.IsSucceeded)
            {
                List<string> errMessages = new List<string>();
                if (!res_firms.IsSucceeded && res_firms.Errors == null) throw new Exception("");
                else
                {
                    errMessages = res_firms.Errors.Select(x => x.ErrorValue).ToList();
                }
                if (!res_roles.IsSucceeded && res_roles.Errors == null) throw new Exception("");
                else
                {
                    errMessages.AddRange(res_roles.Errors.Select(x => x.ErrorValue).ToList());
                }
                return ServiceResult<UserEditingDto>.Fail(errMessages.ToArray());
            }

            var dto_firms = res_firms.Data.Select(x => new FirmListing_BasicDto { Id = x.Id, Name = x.Name, IsSelected = false }).ToList();
            var dto_roles = res_roles.Data.Select(x => new RoleListing_basicDto { Id = x.Id, Name = x.Name, IsSelected = false }).ToList();



            var dto = mapper.Map<UserEditingDto>(res.Data);
            dto.Roles.ForEach(x=>x.IsSelected=true);
            dto.Firms.ForEach(x => x.IsSelected = true);

            dto_firms.ForEach(x => { if (!dto.Firms.Any(f => f.Id == x.Id)) { dto.Firms.Add(x); } });
            dto_roles.ForEach(x => { if (!dto.Roles.Any(f => f.Id == x.Id)) { dto.Roles.Add(x); } });


            return ServiceResult<UserEditingDto>.Success(dto);
        }
        async public Task<ServiceResult> UpdateUser(UserEditingDto dto)
        {
            var model = mapper.Map<UserTable>(dto);
            model.Firms = dto.SelectedFirms.Select(x => new Firm { Id = x }).ToList();
            model.Roles = dto.SelectedRoles.Select(x => new RoleTable { Id = x }).ToList();
            var res = await managerUser.Update(model);
            if (res.IsSucceeded) return ServiceResult.Success();
            return ServiceResult.Fail(res.Errors.Select(x => x.ToString()).ToArray());
        }
        #endregion


    }
}
