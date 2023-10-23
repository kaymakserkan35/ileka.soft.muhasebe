using data.access.context;
using service.Mapper;

using Microsoft.AspNetCore.Identity;

using entity.concretes.identity;
using ui.Mapper;
using AutoMapper;

namespace ui.DependencyResolver
{
    public static class DependencyResolver
    {
        public static void AddMyUiDependencies(this IServiceCollection Services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>()
              { new DtoModelMapperProfile()  });
            });
            var mapper = new DtoModelMapper(config);
            Services.AddSingleton<IDtoModelMapper>(mapper);




            Services.AddIdentity<UserTable, RoleTable>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

            Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin() // Tüm kök URL'lere izin ver
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


        }
    }
}
