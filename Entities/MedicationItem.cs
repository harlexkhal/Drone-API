using DroneAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DroneAPI.Entities
{
    public class MedicationItem
    {
        [Key]
        public int Id { get; set; }
        public int DroneSerialNumber { get; set; }
        public int Weight { get; set; }
        public int Code { get; set; }
        public string ImageUrl { get; set; }
    }
}