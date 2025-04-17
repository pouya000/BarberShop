using BarberShop.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Context
{
    public class BarberShopDbContext : IdentityDbContext<T_User>
    {
        public BarberShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<T_User> T_Users { get; set; }
        public DbSet<T_BarberShop> T_BarberShops { get; set; }
        public DbSet<T_Appointment> T_Appointments { get; set; }
    }
}
