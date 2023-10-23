using business.Response;

using entity.abstraction;
using entity.concretes.entities;
using entity.concretes.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace business.data.works.concrete.abstractions.interfaces
{

    /// <summary>
    /// cachleme yapılıcak ve iş kuralları eklenicek
    /// </summary>
    public interface IManager
    {

    }

    public interface IManagerUser : IManagerGeneric<UserTable>, IManager
    {
        /// <returns>  list of  {user : {
        /// id,name,surname,createdDate,email,phone, firm={name}, role={name}
        /// }} </returns>
        public abstract Task<BusinessResult<List<UserTable>>> readUsersWithFirmsAndRoles_forListing();
        /// <returns>    {user : {
        /// id,name,surname,createdDate,email,phone, firm={name}, role={name}
        /// }} </returns>
        public abstract Task<BusinessResult<UserTable>> readUserWithFirmsAndRoles(int id);


        /// <returns>  {user : {
        /// id,name,surname,createdDate,email,phone, firm={name}
        /// }} </returns>
        public abstract Task<BusinessResult<List<UserTable>>> readUsersWithFirms_forListing();
    }
    public interface IManagerRole : IManagerGeneric<RoleTable>, IManager
    {

    }
    public interface IManagerCity : IManagerGeneric<City>, IManager
    {

    }
    public interface IManagerDistrict : IManagerGeneric<District>, IManager
    {
        public abstract Task<BusinessResult<List<District>>> readDistrictsWİthCityAndCountry();
    }
    public interface IManagerCountry : IManagerGeneric<Country>, IManager
    {

    }
    public interface IManagerCari : IManagerGeneric<Contact>, IManager
    {

    }
    public interface IManagerFirm : IManagerGeneric<Firm>, IManager
    {
        public abstract Task<BusinessResult<Firm>> readFirmWithModules(int id);
        public abstract Task<BusinessResult<List<Firm>>> readFirmsWithModules();
        public abstract Task<BusinessResult<List<Firm>>> readFirmsWithModulesAndOwner();
    }

    public interface IManagerBank : IManagerGeneric<Bank>, IManager
    {

    }

    public interface IManagerBankAccount : IManagerGeneric<BankAccount>, IManager
    {

    }
    public interface IManagerBankBranch : IManagerGeneric<BankBranch>, IManager
    {

    }
    public interface IManagerCurrency : IManagerGeneric<Currency>, IManager
    {

    }
    public interface IManagerFirmHasModule : IManagerGeneric<FirmHasModule>, IManager
    {

    }

    public interface IManagerFirmUsers : IManagerGeneric<FirmUsers>, IManager { }

    public interface IManagerModule : IManagerGeneric<Module>, IManager
    {

    }
    public interface IManagerInvoice : IManagerGeneric<Invoice>, IManager
    {

    }
    public interface IManagerInvoiceHasStock : IManagerGeneric<InvoiceHasStock>, IManager
    {

    }
    public interface IManagerStock : IManagerGeneric<Stock>, IManager
    {

    }
    public interface IManagerTaxOffice : IManagerGeneric<TaxOffice>, IManager
    {

    }
    public interface IManagerUnitsOfMeasurement : IManagerGeneric<UnitsOfMeasurement>, IManager
    {

    }
    public interface IManagerVault : IManagerGeneric<Vault>, IManager
    {

    }
    public interface IManagerPaymentMethod : IManagerGeneric<PaymentMethod>, IManager
    {

    }
    public interface IManagerBankAccountType : IManagerGeneric<BankAccountType>, IManager
    {

    }

}
