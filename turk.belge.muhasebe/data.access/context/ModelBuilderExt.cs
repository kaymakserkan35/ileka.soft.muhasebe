using entity.concretes.entities;
using entity.concretes.identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.context
{
    internal static class ModelBuilderExt
    {
        static public void Build(this ModelBuilder builder)
        {
            BuildUserHasRole(builder);
            BuildFirmHasUser(builder);
            BuildFirmHasModule(builder);
            BuilderInvoiceHasStock(builder);

        }

        private static void BuildUserHasRole(ModelBuilder builder)
        {
            builder.Entity<UserTable>(entity =>
            {
                entity.HasMany(u => u.Roles)
                    .WithMany(r => r.Users)
                    .UsingEntity<UserHasRole>(
                        ur => ur.HasOne(uh => uh.RoleTable).WithMany(),
                        ur => ur.HasOne(uh => uh.UserTable).WithMany()
                    );
            });

            // RoleTable konfigürasyonu
            builder.Entity<RoleTable>(entity =>
            {
                entity.Property(r => r.NormalizedName)
                    .HasConversion(n => n, n => n)
                    .IsRequired();

                entity.HasMany(r => r.Users)
                    .WithMany(u => u.Roles)
                    .UsingEntity<UserHasRole>(
                        ur => ur.HasOne(uh => uh.UserTable).WithMany(),
                        ur => ur.HasOne(uh => uh.RoleTable).WithMany()
                    );
            });

            builder.Entity<UserHasRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.UserTable)
                    .WithMany()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                entity.HasOne(ur => ur.RoleTable)
                    .WithMany()
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });
        }
        private static void BuildFirmHasUser(ModelBuilder builder)
        {
            builder.Entity<UserTable>(entity =>
            {


                entity.HasMany(u => u.Firms)
                    .WithMany(r => r.Users)
                    .UsingEntity<FirmUsers>(
                        ur => ur.HasOne(uh => uh.Firm).WithMany(),
                        ur => ur.HasOne(uh => uh.UserTable).WithMany()
                    );
            });

            // RoleTable konfigürasyonu
            builder.Entity<Firm>(entity =>
            {

                entity.HasMany(r => r.Users)
                    .WithMany(u => u.Firms)
                    .UsingEntity<FirmUsers>(
                        ur => ur.HasOne(uh => uh.UserTable).WithMany(),
                        ur => ur.HasOne(uh => uh.Firm).WithMany()
                    );
            });

            builder.Entity<FirmUsers>(entity =>
            {
                entity.HasKey(ur => new { ur.UserTableId, ur.FirmId });

                entity.HasOne(ur => ur.UserTable)
                    .WithMany()
                    .HasForeignKey(ur => ur.UserTableId)
                    .IsRequired();

                entity.HasOne(ur => ur.Firm)
                    .WithMany()
                    .HasForeignKey(ur => ur.FirmId)
                    .IsRequired();
            });



        }
        private static void BuildFirmHasModule(ModelBuilder builder)
        {
            builder.Entity<Module>(entity =>
            {


                entity.HasMany(u => u.Firms)
                    .WithMany(r => r.Modules)
                    .UsingEntity<FirmHasModule>(
                        ur => ur.HasOne(uh => uh.Firm).WithMany(),
                        ur => ur.HasOne(uh => uh.Module).WithMany()
                    );
            });

            // RoleTable konfigürasyonu
            builder.Entity<Firm>(entity =>
            {

                entity.HasMany(r => r.Modules)
                    .WithMany(u => u.Firms)
                    .UsingEntity<FirmHasModule>(
                        ur => ur.HasOne(uh => uh.Module).WithMany(),
                        ur => ur.HasOne(uh => uh.Firm).WithMany()
                    );
            });

            builder.Entity<FirmHasModule>(entity =>
            {
                entity.HasKey(ur => new { ur.ModuleId, ur.FirmId });

                entity.HasOne(ur => ur.Module)
                    .WithMany()
                    .HasForeignKey(ur => ur.ModuleId)
                    .IsRequired();

                entity.HasOne(ur => ur.Firm)
                    .WithMany()
                    .HasForeignKey(ur => ur.FirmId)
                    .IsRequired();
            });



        }
        private static void BuilderInvoiceHasStock(ModelBuilder builder)
        {
            // user -> ınvoice
            // role -> stock
            builder.Entity<Invoice>(entity =>
            {


                entity.HasMany(u => u.Stocks)
                    .WithMany(r => r.Invoices)
                    .UsingEntity<InvoiceHasStock>(
                        ur => ur.HasOne(uh => uh.Stock).WithMany(),
                        ur => ur.HasOne(uh => uh.Invoice).WithMany()
                    );
            });

            // RoleTable konfigürasyonu
            builder.Entity<Stock>(entity =>
            {
                entity.HasMany(r => r.Invoices)
                    .WithMany(u => u.Stocks)
                    .UsingEntity<InvoiceHasStock>(
                        ur => ur.HasOne(uh => uh.Invoice).WithMany(),
                        ur => ur.HasOne(uh => uh.Stock).WithMany()
                    );
            });

            builder.Entity<InvoiceHasStock>(entity =>
            {
                entity.HasKey(ur => new { ur.InvoiceId, ur.StockId });

                entity.HasOne(ur => ur.Invoice)
                    .WithMany()
                    .HasForeignKey(ur => ur.InvoiceId)
                    .IsRequired();

                entity.HasOne(ur => ur.Stock)
                    .WithMany()
                    .HasForeignKey(ur => ur.StockId)
                    .IsRequired();
            });
        }

    }
}
