using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Model
{
    public class T_Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID_Appointment { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public string T_User_ID { get; set; }
        [ForeignKey("T_User_ID")]
        public T_User? User { get; set; }

    }

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Completed,
        Canceled
    }
}
