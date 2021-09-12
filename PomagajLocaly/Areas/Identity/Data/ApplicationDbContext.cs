using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PomagajLocaly.Models;

namespace PomagajLocaly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasOne(b => b.User).WithOne(x => x.Company).HasForeignKey<User>(x => x.CompanyId);
          

        }
    }
}