using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using DroneAPI.Entities;
using DroneAPI.Models;
using DroneAPI.Helpers;

namespace DroneAPI.Services
{
    public interface IDroneService
    {
        object Register(RegisterDroneRequest model);
        object AddMedicationItem(AddMedicalItemRequest model);
        object GetMedicalItems(DroneItemLIstRequest model);
        object FetchAllDrones();
        object CheckBatteryLevel(DroneItemLIstRequest model);
    }

    public class DroneService : IDroneService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public DroneService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public object Register(RegisterDroneRequest model)
        {
            var drone = _mapper.Map<Drone>(model);

            if (drone.Model == 0 || drone.Model > DroneModelType.Heavyweight)
                drone.Model = DroneModelType.Middleweight;

            if (drone.State == 0 || drone.State > DroneState.RETURNING)
            {
                drone.State = DroneState.LOADING;
            }

            if (drone.Battery >= 100)
                drone.Battery = 100;

            if (drone.Battery < 25)
                drone.State = DroneState.IDLE;

            _context.Drones.Add(drone);
            _context.SaveChanges();

            return new { message = "Registration successful" };
        }

        public object AddMedicationItem(AddMedicalItemRequest model)
        {
            var MedicalItem = _mapper.Map<MedicationItem>(model);
            var drone = _context.Drones.SingleOrDefault(x => x.SerialNumber == model.DroneSerialNumber);
            if(drone == null)
                return new { message = "Drone with serial number '" + model.DroneSerialNumber + "' was not found" };

            if(drone.State == DroneState.LOADING)
            {
                if(model.Weight > drone.Weight)
                    return new { message = "The weight of this Item has over exceeded the max weight this drone can carry!" };

                int CalcWeigth = drone.TotalItemWeight + model.Weight;
                if (CalcWeigth > drone.Weight)
                    return new { message = "Spaces are limited in this drone to contain this new item" };

                drone.TotalItemWeight += model.Weight;
                _context.Drones.Update(drone);
                _context.SaveChanges();

                var item = _mapper.Map<MedicationItem>(model);
                _context.MedicationItems.Add(item);
                _context.SaveChanges();

                return new { message = "Medical item added successfully to drone" };
            }

            else
            {
                return new { message = "This drone is not available for loading its current state is '" + drone.State.ToString()};
            }
        }

        public object GetMedicalItems(DroneItemLIstRequest model)
        {
            var drone = _context.Drones.SingleOrDefault(x => x.SerialNumber == model.DroneSerialNumber);
            if (drone == null)
                return new { message = "Drone with serial number '" + model.DroneSerialNumber + "' was not found" };

            return _context.MedicationItems.Where(x => x.DroneSerialNumber == model.DroneSerialNumber);
        }

        public object FetchAllDrones()
        {
            return _context.Drones;
        }

        public object CheckBatteryLevel(DroneItemLIstRequest model)
        {
            var drone = _context.Drones.SingleOrDefault(x => x.SerialNumber == model.DroneSerialNumber);
            if (drone == null)
                return new { message = "Drone with serial number '" + model.DroneSerialNumber + "' was not found" };

            return new { message = "Drone with serial number " + model.DroneSerialNumber + " is at " + drone.Battery + "% battery power" };
        }
    }
}