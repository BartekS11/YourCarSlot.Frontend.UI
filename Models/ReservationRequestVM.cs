using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourCarSlot.Frontend.UI.Models
{
    public class ReservationRequestVM
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserRequestingId { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        [Display(Name="Parking spot number")]
        public int ParkingspotId { get; set; }

        public bool Reserved { get; set; }

    }
}