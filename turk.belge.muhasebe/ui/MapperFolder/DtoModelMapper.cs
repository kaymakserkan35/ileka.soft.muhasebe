using AutoMapper;
using entity.concretes.identity;
using service.Dtos.DistrictDto;
using service.Dtos.FirmDto;
using service.Dtos.ListingDtos;
using service.Dtos.UserDtos;
using service.Mapper;
using ui.Models.DeveloperModel;
using ui.Models.ListingBasicModels;
using ui.Models.ListingModels;
using ui.Models.UserModel;

namespace ui.Mapper
{
    public interface IDtoModelMapper : IMapper
    {
        List<Tout> Map<Tout>(List<FirmDto> data) where Tout : class;
        List<Tout> Map<Tout>(List<DistrictDto> data) where Tout : class;
        List<Tout> Map<Tout>(List<UserDto> data) where Tout : class;
    }
    public class DtoModelMapper : AutoMapper.Mapper, IDtoModelMapper
    {
        public DtoModelMapper(AutoMapper.IConfigurationProvider configuration) : base(configuration)
        {
        }

        public List<Tout>? Map<Tout>(List<UserDto> data) where Tout : class
        {

            List<Tout> list = new List<Tout>();
            foreach (var item in data) { list.Add(Map<Tout>(item)); }
            return list;

        }

        public List<Tout>? Map<Tout>(List<DistrictDto> data) where Tout : class
        {
            List<Tout> list = new List<Tout>();
            foreach (var item in data) { list.Add(Map<Tout>(item)); }
            return list;
        }

        public List<Tout>? Map<Tout>(List<UserListingModel> data) where Tout : class
        {
            List<Tout> list = new List<Tout>();
            foreach (var item in data) list.Add(Map<Tout>(item));
            return list;
        }

        public List<Tout> Map<Tout>(List<FirmDto> data) where Tout : class
        {
            List<Tout> list = new List<Tout>();
            foreach (var item in data) list.Add(Map<Tout>(item));
            return list;
        }
    }

    public class DtoModelMapperProfile : Profile
    {
        public DtoModelMapperProfile()
        {
            CreateMap<UserDto, UserEditingModel>().ReverseMap();
            CreateMap<UserDto, UserListingModel>().ForMember(y => y.Roles, c => c.MapFrom(x => x.Roles.Select(x => x.Name))).ReverseMap();
            CreateMap<UserDto, UserListingBasicModel>().ReverseMap();
            CreateMap<UserEditingDto, UserEditingModel>().ForMember(y => y.SelectedRoles, c => c.MapFrom(x => x.SelectedRoles))
                .ForMember(y => y.SelectedFirms, c => c.MapFrom(x => x.SelectedFirms)).ReverseMap();
            CreateMap<UserEditingDto, UserEditingModel>().ForMember(y => y.Roles, c => c.MapFrom(y => y.Roles))
                .ForMember(y => y.Firms, c => c.MapFrom(x => x.Firms)).ReverseMap();
            CreateMap<RoleListing_basicDto, RoleListingBasicModel>().ReverseMap();


            CreateMap<FirmDto, FirmEditingModel>().ForMember(y => y.Modulles, c => c.MapFrom(x => x.Modules))
                .ForMember(y => y.User, c => c.MapFrom(x => x.Users.FirstOrDefault()))
                .ReverseMap();

            CreateMap<FirmEditingDto, FirmEditingModel>().ForMember(y => y.Modulles, c => c.MapFrom(x => x.Modulles)).ReverseMap();

            CreateMap<FirmAddingModel, FirmEditingDto>().ForMember(y => y.Modulles, c => c.MapFrom(x => x.Modulles)).ReverseMap();
            CreateMap<FirmListingModel, FirmDto>().ReverseMap();

            CreateMap<ModuleListing_basicDto, ModuleListingBasicModel>().ReverseMap();
            CreateMap<FirmDto, FirmListingModel>()
                .ForMember(y => y.Users, c => c.MapFrom(x => x.Users))
                .ForMember(y => y.Modules, c => c.MapFrom(x => x.Modules)).ReverseMap();
            CreateMap<FirmListing_BasicDto, FirmListingBasicModel>().ReverseMap();

            CreateMap<UserEditingDto, UserEditingModel>().ReverseMap();

            CreateMap<DistrictDto, DistrictModel>().ReverseMap();




        }

    }
}
