using Microsoft.AspNetCore.Identity;

namespace Fintech_Hub.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? City { get; set; }

        public string? Contact { get; set; }

        public string? Gender { get; set; }

        public string? Name { get; set; }

        public string? Pincode { get; set; }

        public int? BankId { get; set; }

        //public virtual Bank? Bank { get; set; }

        //public virtual BankAccount? BankAccount { get; set; }

        //public virtual ICollection<BankAccountTransaction> BankAccountTransactions { get; set; } = new List<BankAccountTransaction>();

    }
}
