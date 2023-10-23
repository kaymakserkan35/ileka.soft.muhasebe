
using AutoMapper;
using business.data.access.concrete.services;



using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using service.Logger;
using service.Mapper;
using service.services.abstractions;
using service.services.concretes.developerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.DependencyResolver
{
    public static class DependencyResolver
    {
        public static void AddMyServiceDependencies(this IServiceCollection Services)
        {

            Services.AddLogging();
            Services.AddScoped<IDeveloperService, DeveloperService>();
            Services.AddScoped<IEntityDtoMapper, EntityDtoMapper>();

            Services.AddScoped<IDeveloperDistrictService, DeveloperDistrictService>();
            Services.AddScoped<IDeveloperUserService, DeveloperUserService>();
            Services.AddScoped<IDeveloperFirmService, DeveloperFirmService>();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>()
              { new EntityDtoMapperProfile()  });
            });
            var mapper = new EntityDtoMapper(config);
            Services.AddSingleton<IEntityDtoMapper>(mapper);



            Services.TryAdd(ServiceDescriptor.Singleton(typeof(IMyLogger<>), typeof(MyLogger<>)));
        }
    }
}
