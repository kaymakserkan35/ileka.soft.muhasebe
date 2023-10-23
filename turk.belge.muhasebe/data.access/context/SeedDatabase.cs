using entity.concretes.entities;
using entity.concretes.identity;

using Faker.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static entity.concretes.identity.RoleTable;

namespace data.access.context
{
    public static class SeedDatabase
    {

        #region MyRegion

        public static string[] turkishCities = {
    "Adana",
    "Adıyaman",
    "Afyonkarahisar",
    "Ağrı",
    "Aksaray",
    "Amasya",
    "Ankara",
    "Antalya",
    "Ardahan",
    "Artvin",
    "Aydın",
    "Balıkesir",
    "Bartın",
    "Batman",
    "Bayburt",
    "Bilecik",
    "Bingöl",
    "Bitlis",
    "Bolu",
    "Burdur",
    "Bursa",
    "Çanakkale",
    "Çankırı",
    "Çorum",
    "Denizli",
    "Diyarbakır",
    "Düzce",
    "Edirne",
    "Elazığ",
    "Erzincan",
    "Erzurum",
    "Eskişehir",
    "Gaziantep",
    "Giresun",
    "Gümüşhane",
    "Hakkâri",
    "Hatay",
    "Iğdır",
    "Isparta",
    "İstanbul",
    "İzmir",
    "Kahramanmaraş",
    "Karabük",
    "Karaman",
    "Kars",
    "Kastamonu",
    "Kayseri",
    "Kırıkkale",
    "Kırklareli",
    "Kırşehir",
    "Kilis",
    "Kocaeli",
    "Konya",
    "Kütahya",
    "Malatya",
    "Manisa",
    "Mardin",
    "Mersin",
    "Muğla",
    "Muş",
    "Nevşehir",
    "Niğde",
    "Ordu",
    "Osmaniye",
    "Rize",
    "Sakarya",
    "Samsun",
    "Şanlıurfa",
    "Siirt",
    "Sinop",
    "Sivas",
    "Şırnak",
    "Tekirdağ",
    "Tokat",
    "Trabzon",
    "Tunceli",
    "Uşak",
    "Van",
    "Yalova",
    "Yozgat",
    "Zonguldak"
};
        public static string[] countries = {
                "Türkiye",
                "Amerika Birleşik Devletleri",
                "İngiltere",
                "Almanya",
                "Fransa",
                "İtalya",
                "İspanya",
                "Kanada",
                "Avustralya",
                "Hindistan",
                "Çin",
                "Japonya",
                "Brezilya",
                "Meksika",
                "Rusya",
                "Güney Kore",
                "Güney Afrika",
                "Suudi Arabistan",
                "Birleşik Arap Emirlikleri",
                "Türkmenistan"
                            };
        public static string[] izmirIlceler = {
    "Aliağa",
    "Balçova",
    "Bayındır",
    "Bayraklı",
    "Bergama",
    "Beydağ",
    "Bornova",
    "Buca",
    "Çeşme",
    "Çiğli",
    "Dikili",
    "Foça",
    "Gaziemir",
    "Güzelbahçe",
    "Karaburun",
    "Karşıyaka",
    "Kemalpaşa",
    "Kınık",
    "Kiraz",
    "Konak",
    "Menderes",
    "Menemen",
    "Narlıdere",
    "Ödemiş",
    "Seferihisar",
    "Selçuk",
    "Tire",
    "Torbalı",
    "Urla"
};
        public static string[] manisaIlceler = {
    "Ahmetli",
    "Akhisar",
    "Alaşehir",
    "Demirci",
    "Gördes",
    "Kırkağaç",
    "Köprübaşı",
    "Kula",
    "Salihli",
    "Sarıgöl",
    "Saruhanlı",
    "Selendi",
    "Soma",
    "Turgutlu",
    "Yunusemre"
};
        public static string[] bankalar = {
    "İş Bankası",
    "Garanti Bankası",
    "Ziraat Bankası",
    "Akbank",
    "VakıfBank",
    "Halk Bankası",
    "Finans Bankası",
    "Yapı Kredi Bankası",
    "QNB Finansbank",
    "Şekerbank",
    "TEB (Türk Ekonomi Bankası)",
    "Denizbank",
    "Kuveyt Türk Katılım Bankası",
    "HSBC Banks",
    // ... Diğer bankalar buraya eklenir ...
};

        #endregion


        public static void Seed()
        {
            SeedRoles_00();
            SeedFirmsAndUsers_0();
            SeedModules_00();
            seedFİrmModules_01();
            SeedDeveloper_1();
            SeedCountry_2();
            SeedCity_3();
            SeedDistrict_4();
            SeedBank_5();
            SeedBankAccountType_6();
            SeedTaxOffice_7();
            SeedCuurency_8();

            SeedPaymentMethod_10();
            SeedUnitsOfMeasurement_11();
            seedCariGroup_12();
            seedCariler_13();
            SeedBankAccount_14();
            seedIncoiveSubtypes_15();
            seedInvoiceTypes_16();
            seedStocks_17();
            seedInvoice_18();
        }

        public static DatabaseContext db;


        public static void SeedRoles_00()
        {
            if (db.Roles.Any()) return;

            string[] types = Enum.GetNames(typeof(RolesEnum));
            foreach (var typ in types)
            {
                db.Roles.Add(new RoleTable(typ));
            }


            db.SaveChanges();


        }

        public static void SeedFirmsAndUsers_0()
        {

            List<Firm> firmList = new List<Firm>();
            List<UserTable> users = new List<UserTable>();
            for (int i = 0; i < 25; i++)
            {
                Firm firm = new Firm()
                {
                    Name = Faker.Company.Name(),
                    EMail = Faker.Name.First() + "@gmail.com",
                    PhoneNumber = Faker.Phone.Number(),
                    SoleTrader = Faker.Boolean.Random(),
                };
                var user = new UserTable()
                {
                    Name = Faker.Name.First(),
                    SurName = Faker.Name.Last(),
                    UserName = Faker.Name.FullName(),
                    PhoneNumber = Faker.Phone.Number(),
                    NormalizedEmail = "@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.UtcNow
                };
                user.Email = user.Name + "." + user.SurName + "@gmail.com";
                user.NormalizedEmail = user.Email.ToUpper();
                var role = db.Roles.AsTracking().First(x => x.Name == RolesEnum.CUSTOMER.ToString());
                user.Roles = new List<RoleTable> { role };

                users.Add(user);
                firmList.Add(firm);
            }
            db.Users.AddRange(users);
            db.SaveChanges();

            foreach (var firm in firmList)
            {
                for (int i = 0; i < 5; i++)
                {
                    int r = new Random().Next(0, users.Count);
                    if (!firm.Users.Any(x => x.Id == users[r].Id)) firm.Users.Add(users[r]);
                }
            }
            db.Firms.AddRange(firmList);
            db.SaveChanges();

        }

        public static void SeedModules_00()
        {
            if (db.Modules.Any()) return;
            for (int i = 0; i < 5; i++)
            {
                db.Modules.Add(new Module($"Modül_{i}"));
            }
            db.SaveChanges();

        }

        public static void seedFİrmModules_01()
        {
            var firms = db.Firms.ToList();
            var modules = db.Modules.ToList();
            var r = new Random();
            foreach (var item in firms)
            {
                item.Modules = new List<Module> { modules[r.Next(modules.Count - 1)] };

            }
            db.SaveChanges();
        }
        public static void SeedDeveloper_1()
        {


            if (!db.Users.Any(u => u.Email.Equals("developer.35@gmail.com")))
            {
                // Create a new ADMINISTRATOR user
                var adminUser = new UserTable()
                {
                    Name = "serkan",
                    SurName = "KAYMAK",
                    UserName = "serkan " + "KAYMAK",
                    Email = "developer.35@gmail.com",
                    PhoneNumber = "01234 123 12 12",
                    NormalizedEmail = "developer.35@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.UtcNow,
                    Firms = new List<Firm>() { new Firm() { EMail = "türk.belge@gmail.com", PhoneNumber = "05538774551", SoleTrader = false, Name = "türkbelge" } },



                };
                string password = "dev35!"; // Replace with the desired password
                var passwordHasher = new PasswordHasher<UserTable>();
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, password);
                adminUser.Roles.Add(db.Roles.First(x => x.Name == RolesEnum.DEVELOPER.ToString()));
                db.Users.Add(adminUser);
                db.SaveChanges();
            }
        }

        public static void SeedCountry_2()
        {
            if (db.Countries.Any())
            {
                return;
            }
            List<Country> countryList = new List<Country>();
            foreach (var countryName in countries)
            {
                countryList.Add(new Country(countryName));
            }
            db.AddRange(countryList);
            db.SaveChanges();
        }

        public static void SeedCity_3()
        {


            if (db.Cities.Any()) return;
            Country? country = db.Countries.FirstOrDefault(x => x.Name.Equals("Türkiye"));
            if (country == null) throw new Exception("öncelik ile ülkeleri seed lemeniz gerekmektedir.");
            List<City> cities = new List<City>();
            foreach (var city in turkishCities)
            {
                cities.Add(new City(city, country));
            }

            db.Cities.AddRange(cities);
            db.SaveChanges();
        }

        public static void SeedDistrict_4()
        {
            if (db.Districts.Any()) return;


            Country? country_türkiye = db.Countries.FirstOrDefault(x => x.Name.Equals("Türkiye"));
            if (country_türkiye == null) throw new Exception("öncelik ile ülkeleri seed lemeniz gerekmektedir.");
            City? city_izmir = db.Cities.FirstOrDefault(x => x.Name.Equals("İzmir"));
            City? city_manisa = db.Cities.FirstOrDefault(x => x.Name.Equals("Manisa"));

            if (city_izmir == null || city_manisa == null) throw new Exception("öncelik ile ülkeleri seed lemeniz gerekmektedir.");

            city_izmir.Country = country_türkiye;
            city_manisa.Country = country_türkiye;

            List<District> izmirilçelerListesi = new List<District>();
            foreach (var ilçe in izmirIlceler)
            {
                izmirilçelerListesi.Add(new District(ilçe, city_izmir));
            }
            db.Districts.AddRange(izmirilçelerListesi);
            db.SaveChanges();

            List<District> manisailçelerListesi = new List<District>();
            foreach (var ilçe in manisaIlceler)
            {
                manisailçelerListesi.Add(new District(ilçe, city_manisa));
            }
            db.Districts.AddRange(manisailçelerListesi);
            db.SaveChanges();

        }

        public static void SeedBank_5()
        {
            if (db.Banks.Any()) return;
            {
                var country_turkiye = db.Countries.FirstOrDefault(x => x.Name.Equals("Türkiye"));
                List<Bank> bankaListesi = new List<Bank>();

                foreach (var banka in bankalar)
                {
                    bankaListesi.Add(new Bank(banka));
                }

                foreach (var banka in bankaListesi)
                {
                    foreach (var city in db.Cities.ToArray())
                    {
                        foreach (var district in db.Districts.Where(x => x.CityId == city.Id).ToList())
                        {
                            banka.BankBranches.Add(new BankBranch(district, city, country_turkiye, "adress", "0555 888 77 44") { });
                        }
                    }
                }

                db.Banks.AddRange(bankaListesi);
                db.SaveChanges();
            }
        }

        public static void SeedBankAccountType_6()
        {
            if (db.BankAccountTypes.Any()) return;

            string[] types = Enum.GetNames(typeof(BankAccountTypeEnum));
            foreach (var typ in types)
            {
                db.BankAccountTypes.Add(new BankAccountType(typ));
            }


            db.SaveChanges();
        }

        public static void SeedTaxOffice_7()
        {

            if (db.TaxOfficies.Any()) return;


            List<TaxOffice> TaxOfficeListesi = new List<TaxOffice>();
            Country c = db.Countries.First(x => x.Name.Equals("Türkiye"));
            foreach (var item in db.Districts.Include(x => x.City).ToArray())
            {
                var to = new TaxOffice();
                to.Name = item.Name + " Vergi Dairesi";
                to.Country = c;
                to.City = item.City;
                to.District = item;
                to.CompleteAdress = to.District.Name + "/" + to.City.Name;
                to.Code = to.DistrictId.ToString() + item.CityId.ToString();

                TaxOfficeListesi.Add(to);
            }

            db.TaxOfficies.AddRange(TaxOfficeListesi);
            db.SaveChanges();
        }

        public static void SeedCuurency_8()
        {
            if (db.Currencies.Any()) return;


            Currency currency = new Currency("TL");
            db.Currencies.Add(currency);

            db.Currencies.Add(new Currency("USD"));
            db.SaveChanges();

        }



        public static void SeedPaymentMethod_10()
        {
            if (db.PaymentMethods.Any()) return;
            string[] list = Enum.GetNames(typeof(PaymentMethodEnum));
            foreach (var item in list)
            {
                db.PaymentMethods.Add(new PaymentMethod(item));
            }


            db.SaveChanges();
        }

        public static void SeedUnitsOfMeasurement_11()
        {
            if (db.UnitsOfMeasurements.Any()) return;
            string[] msr = Enum.GetNames(typeof(UnitsOfMeasurementEnum));

            foreach (var item in msr)
            {
                db.UnitsOfMeasurements.Add(new UnitsOfMeasurement(item));
            }



            db.SaveChanges();
        }

        public static void seedCariGroup_12()
        {
            if (db.CariGroups.Any()) return;
            string[] list = Enum.GetNames(typeof(CariGroupEnum));
            foreach (var item in list)
            {
                db.CariGroups.Add(new CariGroup(item));
            }
            db.SaveChanges();
        }

        public static void seedCariler_13()
        {
            var r = new Random();

            List<CariGroup> cariGroups = db.CariGroups.ToList();
            List<District> districts = db.Districts.ToList();
            List<City> cities = db.Cities.ToList();
            List<TaxOffice> taxOffices = db.TaxOfficies.ToList();
            List<UserTable> users = db.Users.Include(x => x.Firms).ToList();

            for (int i = 1; i < 150; i++)
            {
                var user = users[r.Next(users.Count - 1)];
                Contact cari = new Contact()
                {
                    Name = Faker.Name.First(),
                    CompanyName = Faker.Company.Name(),
                    SurName = Faker.Name.Last(),
                    TaxIdentificationNumber = r.Next(00, 10000),
                    CariGroup = cariGroups[r.Next(cariGroups.Count - 1)],
                    City = cities[r.Next(cities.Count - 1)],
                    District = districts[r.Next(districts.Count - 1)],
                    WebSite = $"www.website_{r.Next(100)} .com",
                    TaxOffice = taxOffices[r.Next(taxOffices.Count - 1)],
                    PhoneNumber = Faker.Phone.Number(),
                    Status = true,
                    CompleteAdress = Faker.Address.SecondaryAddress(),
                    UserTable = user,
                    Country = db.Countries.SingleOrDefault(x => x.Name.Equals("Türkiye")),
                    CreatedDate = DateTime.UtcNow,
                    Firm = user.Firms.First(),
                    PostalCode = Faker.Address.UkPostCode(),
                };

                db.Contacts.Add(cari);
            }
            db.SaveChanges();






        }

        public static void SeedBankAccount_14()
        {
            List<Currency> currencies = db.Currencies.ToList();
            // List<Bank> banks = db.Banks.ToList();
            List<BankAccountType> bankAccountTypes = db.BankAccountTypes.ToList();
            List<BankBranch> bankBranches = db.BankBranches.ToList();
            List<Firm> firms = db.Firms.ToList();

            var r = new Random();
            for (int i = 0; i < 45; i++)
            {
                var ba = new BankAccount
                {
                    AccountNo = Guid.NewGuid().ToString(),

                    BankAccountType = bankAccountTypes[r.Next(bankAccountTypes.Count - 1)],
                    Currency = currencies[r.Next(currencies.Count - 1)],
                    BankBranch = bankBranches[r.Next(bankBranches.Count - 1)],
                    Iban = Guid.NewGuid().ToString(),
                    Firm = firms[r.Next(firms.Count - 1)],
                };
                db.BankAccounts.Add(ba);
            }
            db.SaveChanges();

        }

        public static void seedIncoiveSubtypes_15()
        {
            string[] types = Enum.GetNames(typeof(InvoiceSubTypeEnum));
            foreach (var item in types)
            {
                db.InvoiceSubTypes.Add(new InvoiceSubType { Name = item });
            }
            db.SaveChanges();
        }

        public static void seedInvoiceTypes_16()
        {

            string[] types = Enum.GetNames(typeof(InvoiceTypeEnum));
            foreach (var item in types)
            {
                db.InvoiceTypes.Add(new InvoiceType
                {
                    Name = item
                });
            }
            db.SaveChanges();
        }


        public static void seedStocks_17()
        {
            string[] types = Enum.GetNames(typeof(StockCategoryEnum));
            foreach (var item in types)
            {
                db.Add(new StockCategory
                {
                    Name = item
                });
            }
            db.SaveChanges();

            var stockCategories = db.StockCategories.ToList();

            var r = new Random();
            var users = db.Users.ToList();
            var measurenmntes = db.UnitsOfMeasurements.ToList();
            foreach (var user in users)
            {
                var stock = new Stock
                {
                    Name = $"{user.Name} stogu ",
                    UserTable = user,
                    Firm = user.Firms.First(),
                    Description = Faker.Lorem.Sentence(),
                    CostKDV = r.Next(1, 10),
                    LastUpdatedDate = DateTime.UtcNow,
                    MinimumStockLevel = r.Next(3, 15),
                    ProductBarcodeNo = Guid.NewGuid().ToString(),
                    StockCategory = stockCategories[r.Next(stockCategories.Count - 1)],
                    ProductImageUrl = "images/" + Guid.NewGuid().ToString() + ".jpeg",
                    Quantity = r.Next(50),
                    UnitCost = r.NextDouble(),
                    SellingKDV = r.NextDouble(),
                    SellingUnitPrice = r.NextDouble(),
                    SpecialNotes = Faker.Lorem.Sentence(),
                    UnitsOfMeasurement = measurenmntes[r.Next(measurenmntes.Count - 1)]


                };
                db.Stocks.Add(stock);
            }
            db.SaveChanges();
        }

        public static void seedInvoice_18()
        {

            List<InvoiceSubType> invoiceSubTypes = db.InvoiceSubTypes.ToList();
            List<InvoiceType> invoiceTypes = db.InvoiceTypes.ToList();
            List<Currency> currencies = db.Currencies.ToList();
            List<Contact> caris = db.Contacts.ToList();
            List<UserTable> users = db.Users.Include(x => x.Firms).ToList();
            List<Firm> firms = db.Firms.ToList();
            var r = new Random();

            for (int i = 1; i < 50; i++)
            {
                var invoice = new Invoice
                {
                    Contact = caris[r.Next(caris.Count - 1)],
                    UserTable = users[r.Next(users.Count - 1)],
                    Currency = currencies[r.Next(currencies.Count - 1)],
                    CurrentExchangeRate = r.NextDouble(),
                    DueDate = DateTime.UtcNow,
                    LastUpdatedDate = DateTime.UtcNow,
                    PaymentDate = DateTime.UtcNow,
                    InvoiceStatüs = true,
                    PaymentStatüs = false,
                    DeliveryNoteNo = Faker.Lorem.Sentence(),

                    InvoiceType = invoiceTypes[r.Next(invoiceTypes.Count - 1)],
                    InvoiceSubType = invoiceSubTypes[r.Next(invoiceSubTypes.Count - 1)],
                    Description = Faker.Lorem.Paragraph(),
                    DiscountTotal = r.NextDouble(),
                    GrandTotal = r.NextDouble(),
                    InvoiceNo = Guid.NewGuid().ToString(),
                    NetAmount = r.NextDouble(),
                    Subtotal = r.NextDouble(),
                    VatTotal = r.NextDouble(),
                    TotalIncludingTax = r.NextDouble(),
                    WithholdingTaxTotal = r.NextDouble(),
                    Stocks = new List<Stock> { }

                };
                var stocks = db.Stocks.Where(x => x.FirmId.Equals(invoice.UserTable.Firms.First().Id)).ToList();
                invoice.Stocks = new List<Stock>()
                {
                    stocks[r.Next( stocks.Count-1 )], stocks[r.Next( stocks.Count-1 )]
                };

                db.Invoices.Add(invoice);
            }
            db.SaveChanges();

        }

    }
}
