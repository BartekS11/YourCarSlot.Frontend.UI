using System.ComponentModel.DataAnnotations;

namespace YourCarSlot.Frontend.UI.Models
{
    public class ReservationRequestVM
    {
        public Guid Id 
        {   get { return Guid.TryParse(IdAsString, out Guid g) ? g : default; }
            set { IdAsString = Convert.ToString(value); }
        }
        public string IdAsString { get; set; } = String.Empty;
        public string UserRequestingIdAsString { get; set;} = String.Empty;
        [Required]
        public Guid UserRequestingId 
        {
            get { return Guid.TryParse(UserRequestingIdAsString, out Guid g) ? g : default; }
            set { UserRequestingIdAsString = Convert.ToString(value); }
        }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        [Display(Name="Parking spot number")]
        public int ParkingspotId { get; set; }

        public bool Reserved { get; set; }

    }
}