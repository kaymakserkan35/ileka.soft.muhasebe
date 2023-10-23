using business.data.works.concrete.abstractions;
using business.data.access.concrete.services;
using business.data.works.concrete.abstractions.interfaces;
using business.data.works.concrete.managers;


using manager.data.works.concrete.cache;
using manager.data.works.logics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using manager.data.works.concrete.managers;
using manager.data.works.concrete.managers.ManagerRar;

namespace business.DependencyServices
{
    public static class DependencyResolver
    {
        public static void AddMyBusinessDependencies(this IServiceCollection Services)
        {

            Services.AddScoped<IUserLogic, UserLogic>();


            Services.AddScoped<IManagerDistrict, ManagDistrict>();
            Services.AddScoped<IManagerDistrictCached, ManagerDistrictCached>();

            Services.AddScoped<IManagerCity, ManagCity>();
            Services.AddScoped<IManagerCityCached, ManagerCityCached>();


            Services.AddScoped<IManagerCountry, ManagCountry>();
            Services.AddScoped<IManagerCountryCached, ManagerCountryCached>();


            Services.AddScoped<IManagerFirm, ManagFirm>();
            Services.AddScoped<IManagerFirmCached, ManagerFirmCached>();


            Services.AddScoped<IManagerUser, ManagUser>();
            Services.AddScoped<IManagerUserCached, ManagerUserCached>();


            Services.AddScoped<IManagerRole, ManagRole>();
            Services.AddScoped<IManagerRoleCache, ManagerRoleCached>();



            Services.AddScoped<IManagerModule, ManagModule>();
            Services.AddScoped<IManagerModuleCached, ManagerModuleCached>();




            Services.AddScoped<IManagerBankBranch, ManagBankBranch>();
            Services.AddScoped<IManagerBankBranchCached, ManagerBankBranchCached>();



        }
    }
}
