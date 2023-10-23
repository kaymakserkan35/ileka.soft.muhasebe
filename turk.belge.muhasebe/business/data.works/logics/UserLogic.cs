using business.Response;
using entity.concretes.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager.data.works.logics
{
    internal class UserLogic : IUserLogic
    {
       

        public List<ABusinessError>? analyse(UserTable entity)
        {
            List<ABusinessError>? errors = null;
            if (!entity.Email.Contains('@'))
            {
                if (errors == null) errors = new List<ABusinessError>();
                errors.Add(new ValidationError($"{entity.Email} uygun bir değere sahip değildir."));
            }

            if (entity.Name.StartsWith("s"))
            {
                if (errors == null) errors = new List<ABusinessError>();
                errors.Add(new ValidationError($"{entity.Name} s harfi ile başlıyamaz"));
            }

            return errors;
        }
    }
}
