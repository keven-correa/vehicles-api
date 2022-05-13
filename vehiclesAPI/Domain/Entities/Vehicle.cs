using System.ComponentModel.DataAnnotations;
using vehiclesAPI.Domain.enums;

namespace vehiclesAPI.Domain.Entities
{
    public class Vehicle 
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public VehicleStatus Status { get; set; } = VehicleStatus.New;
    }
}
