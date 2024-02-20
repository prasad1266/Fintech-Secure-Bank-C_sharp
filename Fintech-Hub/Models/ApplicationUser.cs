using Microsoft.AspNetCore.Identity;

namespace Fintech_Hub.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? City { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public string? Gender { get; set; }

        public string? Name { get; set; }

        public string? Pincode { get; set; }

        public Bank bank { get; set; }

        public virtual BankAccount? BankAccount { get; set; }



        //public virtual Bank? Bank { get; set; }

        //public virtual BankAccount? BankAccount { get; set; }

        //public virtual ICollection<BankAccountTransaction> BankAccountTransactions { get; set; } = new List<BankAccountTransaction>();

    }
}
