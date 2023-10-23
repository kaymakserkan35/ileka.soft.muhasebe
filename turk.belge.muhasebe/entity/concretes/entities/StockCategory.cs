using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    public enum StockCategoryEnum
    {

        Aksesuar, Elbise, Saf_Malzeme
    }
    public class StockCategory : AEntity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        //[Benzersiz]

        public override string? Name { get => base.Name; set => base.Name = value; }

    }
}
