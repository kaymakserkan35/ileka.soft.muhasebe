using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{

    // satacağımız modülleri temsil edicek
    public class Module : AEntity
    {
        public Module()
        {
            Firms = new HashSet<Firm>();
        }
        public Module(string name)
        {
            Firms = new HashSet<Firm>();
            Name = name;
        }


        public ICollection<Firm> Firms { get; set; }


    }
}
