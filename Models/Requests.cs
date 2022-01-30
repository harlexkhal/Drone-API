using System.ComponentModel.DataAnnotations;

namespace DroneAPI.Models
{
    public class RegisterDroneRequest
    {
        [Required]
        public DroneModelType Model { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Battery { get; set; }
        [Required]
        public DroneState State { get; set; }
    }

    public class AddMedicalItemRequest
    {
        [Required]
        public int DroneSerialNumber { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Code { get; set; }
        public string ImageUrl { get; set; }
    }

    public class DroneItemLIstRequest
    {
        [Required]
        public int DroneSerialNumber { get; set; }
    }
}