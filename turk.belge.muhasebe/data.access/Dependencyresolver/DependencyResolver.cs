


using data.access.context;

using Microsoft.AspNetCore.Identity;
using entity.concretes.entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.Dependencyresolver
{
    public static class DependencyResolver
    {
        public static void AddMyDataAccessDependencies(this IServiceCollection Services)
        {
          


            Services.AddDbContext<DatabaseContext>();





        }
    }
}
