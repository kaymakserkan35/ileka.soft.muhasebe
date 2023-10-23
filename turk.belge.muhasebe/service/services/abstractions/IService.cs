using business.Response;
using entity;
using service.Dtos.DistrictDto;
using service.Dtos.FirmDto;
using service.Dtos.UserDtos;
using service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.services.abstractions
{
    /// <summary>
    /// loglama  ve entity-dto dönüşümleri yapılacak.
    /// data acces ve ya manager daki gibi tek tek tablolara odaklanılmıyacak. doğrudan sayfa etkileşimli karmaşık isteklere yanıt verebilecek methodlar yazılacak.
    /// gereksinim lere göre manager sınıfları düzenlenecek.
    /// </summary>
    public interface IService { }
   
    public interface IDeveloperUserService : IService
    {
        Task<ServiceResult<UserEditingDto>> AddUser();
        Task<ServiceResult> AddUser(UserEditingDto dto);
        Task<ServiceResult<List<UserDto>>> ListUser();
        Task<ServiceResult> deleteUser(int id);
        Task<ServiceResult<UserEditingDto>> UpdateUser(int id);
        Task<ServiceResult> UpdateUser(UserEditingDto dto);
    }


    public interface IDeveloperDistrictService : IService
    {
        Task<ServiceResult> deleteDistrict(int id);
        Task<ServiceResult<List<DistrictDto>>> ListDistrict();

    }

    public interface IDeveloperFirmService : IService
    {

        Task<ServiceResult<FirmEditingDto>> AddFirm();
        Task<ServiceResult> AddFirm(FirmEditingDto dto);
        Task<ServiceResult<List<FirmDto>>> ListFirm();
        Task<ServiceResult> deleteFirm(int id);
        Task<ServiceResult<FirmEditingDto>> UpdateFirm(int id);
        Task<ServiceResult> UpdateFirm(FirmEditingDto dto);
    }
    public interface IDeveloperService : IDeveloperUserService, IDeveloperFirmService , IDeveloperDistrictService { }
}
