using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelQueue.Models;
using FuelQueue.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace FuelQueue.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class FuelStationController : Controller
    {
        private readonly FuelStationService _fuelStationService;

        public FuelStationController(FuelStationService fuelStationService)
        {
            this._fuelStationService = fuelStationService;
        }
        

        // GET Fuel Stations
        [HttpGet]
        public ActionResult<List<FuelStation>> Get()
        {
            return _fuelStationService.Get();
        }

        // GET Fuel Station by Id
        [HttpGet("{id}")]
        public ActionResult<FuelStation> Get(string id)
        {
            var station = _fuelStationService.Get(id);

            if (station == null) return NotFound($"Station with Id = {id} not Found");

            return station;
        }

        // POST Fuel Station
        [HttpPost]
        public ActionResult<FuelStation> Post([FromBody] FuelStation station)
        {
            _fuelStationService.Create(station);

            return CreatedAtAction(nameof(Get), new { id = station.Id }, station);
        }

        // PUT Fuel Station
        [HttpPut("{id}")]
        public ActionResult<FuelStation> Put(string id, [FromBody] FuelStation station)
        {
            var existingStation = _fuelStationService.Get(id);

            if (existingStation == null) return NotFound($"Station with Id = {id} not found");

            _fuelStationService.Update(id, station);

            return NoContent();
        }

        // DELETE Fuel Station
        [HttpDelete("{id}")]
        public ActionResult<FuelStation> Delete(string id)
        {
            
            var existingStation = _fuelStationService.Get(id);

            if (existingStation == null) return NotFound($"Station with Id = {id} not found");

            _fuelStationService.Remove(existingStation.Id);

            return Ok($"Station with ID = {id} deleted");
        }
    
    }
}