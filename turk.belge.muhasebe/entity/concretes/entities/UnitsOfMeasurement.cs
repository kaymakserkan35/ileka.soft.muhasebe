using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    public enum UnitsOfMeasurementEnum
    {
        cm, m_2, kg, kwt, ltr
    }
    public class UnitsOfMeasurement : AEntity
    {

        public UnitsOfMeasurement()
        {

        }

        public UnitsOfMeasurement(string name)
        {
            Name = name;
        }



    }
}
