using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Model
{
    public class T_User : IdentityUser
    {
        [StringLength(60)]
        [Required]
        public string FullName { get; set; }
        [StringLength(250)]
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public Role UserRole { get; set; } // didnt save in db


    }
    public enum Role
    {
        Client,
        Barber,
        BarberShopOwner
    }
}
