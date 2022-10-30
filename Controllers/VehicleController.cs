
using FuelQueue.Models;
using FuelQueue.Services;
using Microsoft.AspNetCore.Mvc;


namespace FuelQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }
        // GET Vehicle
        [HttpGet]
        public ActionResult<List<Vehicle>> Get()
        {
            return _vehicleService.Get();
        }

        // GET by ID
        [HttpGet("{id}")]
        public ActionResult<Vehicle> Get(string id)
        {
            var vehicle = _vehicleService.Get(id);

            if (vehicle == null) return NotFound($"Vehicle with Id = {id} not Found");

            return vehicle;
        }

        // POST Vehicle
        [HttpPost]
        public ActionResult<Vehicle> Post([FromBody] Vehicle vehicle)
        {
            _vehicleService.Create(vehicle);

            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        // PUT Vehicle
        [HttpPut("{id}")]
        public ActionResult<Vehicle> Put(string id, [FromBody] Vehicle vehicle)
        {
            var existingVehicle = _vehicleService.Get(id);

            if (existingVehicle == null) return NotFound($"Vehicle with Id = {id} not found");

            _vehicleService.Update(id, vehicle);

            return NoContent();
        }

        // DELETE Vehicle
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(string id)
        {
            var existingVehicle = _vehicleService.Get(id);

            if (existingVehicle == null) return NotFound($"Vehicle with Id = {id} not found");

            _vehicleService.Remove(existingVehicle.Id);

            return Ok($"Vehicle with ID = {id} deleted");
        }
    }
}
