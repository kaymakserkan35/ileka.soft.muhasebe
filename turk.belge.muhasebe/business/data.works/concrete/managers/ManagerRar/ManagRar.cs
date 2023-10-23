using business.data.access.concrete.abstractions;
using business.data.works.concrete.abstractions.interfaces;
using data.access.context;
using manager.data.works.abstractions.ManagerRar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.managers.ManagerRar
{
    public class ManagDistrict : AManagerDistrict, IManagerDistrict
    {
        public ManagDistrict(DatabaseContext db) : base(db)
        {
        }
    }
    public class ManagCity : AManagerCity, IManagerCity
    {
        public ManagCity(DatabaseContext db) : base(db)
        {
        }
    }
    public class ManagCountry : AManagerCountry, IManagerCountry
    {
        public ManagCountry(DatabaseContext db) : base(db)
        {
        }
    }
    public class ManagBankBranch : AManagerBankBranch, IManagerBankBranch
    {
        public ManagBankBranch(DatabaseContext db) : base(db)
        {
        }
    }


}
