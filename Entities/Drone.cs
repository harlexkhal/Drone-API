using DroneAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DroneAPI.Entities
{
    public class Drone
    {
        [Key]
        public int SerialNumber { get; set; }
        public DroneModelType Model { get; set; }
        public int Weight { get; set; }
        public int Battery { get; set; }
        public DroneState State { get; set; }
        public int TotalItemWeight { get; set; }
    }
}