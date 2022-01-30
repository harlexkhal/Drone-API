using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DroneAPI.Models;
using DroneAPI.Services;

namespace DroneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {
        private IDroneService _droneService;
        private IMapper _mapper;

        public DroneController(
            IDroneService userService,
            IMapper mapper)
        {
            _droneService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDroneRequest model)
        {
            return Ok(_droneService.Register(model));
        }

        [HttpPost("add-medical-item")]
        public IActionResult AddMedicalItem(AddMedicalItemRequest model)
        {
            return Ok(_droneService.AddMedicationItem(model));
        }

        [HttpGet("fetch-medical-items")]
        public IActionResult FetchMedicalItems(DroneItemLIstRequest model)
        {
            return Ok(_droneService.GetMedicalItems(model));
        }

        [HttpGet("fetch-all-drones")]
        public IActionResult FetchAllDrones()
        {
            return Ok(_droneService.FetchAllDrones());
        }

        [HttpGet("fetch-battery-percent")]
        public IActionResult FetchAllDrones(DroneItemLIstRequest model)
        {
            return Ok(_droneService.CheckBatteryLevel(model));
        }
    }
}
