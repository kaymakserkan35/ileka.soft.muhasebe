using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.abstraction;

namespace entity.concretes.entities
{
    public enum BankAccountTypeEnum
    {
        vadesiz_hesap, cari_hesap, mevduat_hesabı
    }
    /// <summary>
    /// bizim için ne kadar gerekli bilemiyorum ancak önceki veritabanında var ve  durmasında fayda var. ileride belki diyerek..., 
    /// </summary>
    public class BankAccountType : AEntity
    {
        public BankAccountType()
        {

        }
        public BankAccountType(string name)
        {
            Name = name;
        }

    }
}
