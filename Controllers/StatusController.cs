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
    public class StatusController : Controller
    {
        private readonly StatusService _statusService;

        public StatusController(StatusService statusService)
        {
            this._statusService = statusService;
        }
        

         // GET Status
        [HttpGet]
        public ActionResult<List<Status>> Get()
        {
            return _statusService.Get();
        }

        // GET BY STATION ID
        [HttpGet("station/{id}")]
        public ActionResult<List<Status>> GetByStation(string id)
        {
            return _statusService.GetByStation(id);
        }


        // GET by ID
        [HttpGet("{id}")]
        public ActionResult <Status> Get(string id)
        {
            return _statusService.Get(id);
        }

        // POST Status
        [HttpPost]
        public ActionResult <Status> Post([FromBody] Status status)
        {
            var existingStatus1 = _statusService.GetByDate(status.date);
            var existingStatus2 = _statusService.GetByType(status.fuelType);

            if ((existingStatus1 != null) && (existingStatus2 != null)) return StatusCode(201, "Status for today is already Insertd");

            _statusService.Create(status);
            CreatedAtAction(nameof(Get), new { id = status.Id }, status);
            return Ok("Successfully Added");

        }

        // PUT Status
        [HttpPut("{id}")]
        public ActionResult<Status> Put(string id, [FromBody] Status status)
        {
            var existingStatus = _statusService.Get(id);

            if (existingStatus == null) return NotFound($"Status with Id = {id} not found");

            _statusService.Update(id, status);

            return Ok($"Station with ID = {id} Updates");
        }

        // DELETE Status
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStatus = _statusService.Get(id);

            if (existingStatus == null) return NotFound($"Status with Id = {id} not found");

            _statusService.Remove(existingStatus.Id);

            return Ok($"Station with ID = {id} deleted");
        }
    }
}