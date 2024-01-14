using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fintech_Hub.Data
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}
