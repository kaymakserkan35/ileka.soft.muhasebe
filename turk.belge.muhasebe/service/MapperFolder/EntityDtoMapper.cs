using AutoMapper;
using entity.concretes.entities;
using entity.concretes.identity;
using service.Dtos;
using service.Dtos.DistrictDto;
using service.Dtos.FirmDto;
using service.Dtos.ListingDtos;
using service.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace service.Mapper
{
    public interface IEntityDtoMapper : IMapper
    {
        List<Tout> Map<Tout>(List<UserDto> data) where Tout : class;
        List<Tout> Map<Tout>(List<UserTable> data) where Tout : class;

        List<Tout> Map<Tout>(List<Firm> data) where Tout : class;
        List<Tout> Map<Tout>(List<FirmDto> data) where Tout : class;

        List<Tout> Map<Tout>(List<District> data) where Tout : class;
        List<Tout> Map<Tout>(List<DistrictDto> data) where Tout : class;

        List<Tout> Map<Tout>(List<ModuleListing_basicDto> data) where Tout : class;


    }
    public class EntityDtoMapper : AutoMapper.Mapper, IEntityDtoMapper
    {

        public EntityDtoMapper(IConfigurationProvider configuration) : base(configuration)
        {
        }

        public List<Tout> Map<Tout>(List<UserDto> data) where Tout : class
        {
            return convertToList<Tout, UserDto>(data);
        }

        public List<Tout> Map<Tout>(List<UserTable> data) where Tout : class
        {
            return convertToList<Tout, UserTable>(data);
        }

        public List<Tout> Map<Tout>(List<Firm> data) where Tout : class
        {
            return convertToList<Tout, Firm>(data);
        }

        public List<Tout> Map<Tout>(List<FirmDto> data) where Tout : class
        {
            return convertToList<Tout, FirmDto>(data);
        }

        public List<Tout> Map<Tout>(List<District> data) where Tout : class
        {
            return convertToList<Tout, District>(data);
        }

        public List<Tout> Map<Tout>(List<DistrictDto> data) where Tout : class
        {
            return convertToList<Tout, DistrictDto>(data);
        }

        public List<Tout> Map<Tout>(List<ModuleListing_basicDto> data) where Tout : class
        {

            return convertToList<Tout, ModuleListing_basicDto>(data);

        }
        private List<Tout> convertToList<Tout, T>(List<T> dataList) where Tout : class
        {
            List<Tout> list = new List<Tout>();
            foreach (var item in dataList) { list.Add(Map<Tout>(item)); }
            return list;
        }
    }

    public class EntityDtoMapperProfile : Profile
    {
        public EntityDtoMapperProfile()
        {
            CreateMap<UserTable, UserDto>().ReverseMap()
          .ForMember(y => y.Roles, conf => conf.MapFrom(x => x.Roles))
          .ForMember(y => y.Firms, conf => conf.MapFrom(x => x.Firms)).ReverseMap();


            CreateMap<UserTable, UserDto>().ReverseMap();
            CreateMap<UserTable, UserEditingDto>().ReverseMap();



            CreateMap<Firm, FirmDto>().ForMember(y => y.Modules, conf => conf.MapFrom(x => x.Modules)).ReverseMap();
            CreateMap<Firm, FirmListing_BasicDto>().ReverseMap();

            CreateMap<Firm, FirmEditingDto>()
                .ForMember(y => y.Modulles, c => c.MapFrom(x => x.Modules))
                .ForMember(y => y.Users, c => c.MapFrom(x => x.Users)) // Kullanıcıları kontrol etmek için FirstOrDefault kullanın
                .ReverseMap();


            CreateMap<Module, ModuleListing_basicDto>().ReverseMap();

            CreateMap<RoleTable, RoleListing_basicDto>().ReverseMap();
            CreateMap<District, DistrictDto>()
                .ForMember(y => y.CountryName, c => c.MapFrom(x => x.City.Country.Name))
                .ForMember(y => y.CityName, c => c.MapFrom(x => x.City.Name)).
                ForMember(y => y.CountryId, c => c.MapFrom(x => x.City.CountryId)).ReverseMap();


        }

    }
}
