using data.access.context;
using manager.data.works.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.concrete.managers
{
    internal class ManagModule : AManagerModule
    {
        public ManagModule(DatabaseContext db) : base(db)
        {
        }
    }
}
