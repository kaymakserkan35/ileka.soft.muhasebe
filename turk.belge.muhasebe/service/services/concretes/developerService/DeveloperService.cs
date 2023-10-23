using AutoMapper;
using business.data.works.concrete.abstractions;
using business.data.access.concrete.services;
using business.data.works.concrete.abstractions.interfaces;
using business.Response;
using data.access.context;
using entity.concretes.entities;
using entity.concretes.identity;
using manager.data.works.concrete.cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
using service.Dtos.FirmDto;
using service.Dtos.DistrictDto;

namespace service.services.concretes.developerService
{
    public class DeveloperService : IDeveloperService
    {
        IDeveloperDistrictService districtService;
        IDeveloperUserService userService;
        IDeveloperFirmService firmService;

        public DeveloperService(IDeveloperUserService userService, IDeveloperFirmService firmService,IDeveloperDistrictService districtService)
        {
            this.districtService= districtService;
            this.userService = userService;
            this.firmService = firmService;
        }

       

        public Task<ServiceResult> AddFirm(FirmEditingDto dto)
        {
            return firmService.AddFirm(dto);
        }

        public async Task<ServiceResult<FirmEditingDto>> AddFirm()
        {
           return await firmService.AddFirm();
        }

        public Task<ServiceResult<UserEditingDto>> AddUser()
        {
           return userService.AddUser();
        }

        public Task<ServiceResult> AddUser(UserEditingDto dto)
        {
           return userService.AddUser(dto);
        }

        public async Task<ServiceResult> deleteDistrict(int id)
        {
            // loglama

           return await  districtService.deleteDistrict(id);
        }

        public async Task<ServiceResult> deleteFirm(int id)
        {
           return await firmService.deleteFirm(id);
        }

        public async Task<ServiceResult> deleteUser(int id)
        {
            return await userService.deleteUser(id);
        }

        public async Task<ServiceResult<List<FirmDto>>> ListFirm()
        {
           return await firmService.ListFirm();
        }

        public async Task<ServiceResult<List<UserDto>>> ListUser()
        {
          return await userService.ListUser();
        }

        public async Task<ServiceResult<FirmEditingDto>> UpdateFirm(int id)
        {
            return await firmService.UpdateFirm(id);
        }

        public async Task<ServiceResult> UpdateFirm(FirmEditingDto dto)
        {
            return await firmService.UpdateFirm(dto);
        }

        public async Task<ServiceResult<UserEditingDto>> UpdateUser(int id)
        {
            return await userService.UpdateUser(id);
        }

        public async Task<ServiceResult> UpdateUser(UserEditingDto dto)
        {
            return await userService.UpdateUser(dto);
        }

        async Task<ServiceResult<List<DistrictDto>>> IDeveloperDistrictService.ListDistrict()
        {
            return await districtService.ListDistrict();
        }
    }


}
