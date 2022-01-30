using AutoMapper;
using DroneAPI.Entities;
using DroneAPI.Models;

namespace DroneAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDroneRequest, Drone>();
            CreateMap<AddMedicalItemRequest, MedicationItem>();
        }
    }
}