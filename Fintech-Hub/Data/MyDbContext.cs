using Fintech_Hub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fintech_Hub.Data
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
            
        }
      
        public DbSet<Bank> Banks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<BankAccountTransaction> BankAccountTransactions { get; set; }

    }
}
