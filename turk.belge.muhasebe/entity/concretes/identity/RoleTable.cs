using entity.abstraction;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace entity.concretes.identity
{

    public class RoleTable : IdentityRole<int>, IEntity
    {
        public enum RolesEnum
        {
            //GELİŞTİRİCİ
            DEVELOPER,
            //YÖNETİCİ
            ADMINISTRATOR,
            //MÜŞTERİ
            CUSTOMER,
            //MÜŞTERİ ÇALIŞANLARI
            MEMBER,
            //DESTEK , DIŞARINDAN .NET İ MÜKEMMEL BİLLEN BİRİSİ İÇİN.
            SUPPORTER
        }

        public override string? NormalizedName { get => base.NormalizedName; set => base.NormalizedName = value; }

        public ICollection<UserTable> Users { get; set; }

        public RoleTable()
        {
            Users = new HashSet<UserTable>();
        }
        public RoleTable(string roleName)
        {
            Users = new HashSet<UserTable>();
            Name = roleName;
            NormalizedName = roleName.ToUpper();
        }
    }
}
