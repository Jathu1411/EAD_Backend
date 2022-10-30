using FuelQueue.Models;
using FuelQueue.Services;
using Microsoft.AspNetCore.Mvc;


namespace FuelQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
       private readonly QueueService _queueService;
        public QueueController(QueueService _queueService1)
        {
            this._queueService = _queueService1;
        }
        // Get API
        [HttpGet]
        public ActionResult<List<Queue>> Get()
        {
            return _queueService.Get();
        }

        // GET By ID
        [HttpGet("{id}")]
        public ActionResult<Queue> Get(string id)
        {
            var queue = _queueService.Get(id);

            if (queue == null) return NotFound($"Queue with Id = {id} not Found");

            return queue;
        }

        // GET By station Id
        [HttpGet("station/{id}")]
        public ActionResult<List<Queue>> GetByStation(string id)
        {
            return _queueService.GetByStation(id);
        }

        // POST API
        [HttpPost]
        public ActionResult<Queue> Post([FromBody] Queue queue)
        {
            _queueService.Create(queue);

            return CreatedAtAction(nameof(Get), new { id = queue.Id }, queue);
        }

        // PUT Queue
        [HttpPut("{id}")]
        public ActionResult<Queue> Put(string id, [FromBody] Queue queue)
        {
            var existingQueue = _queueService.Get(id);

            if (existingQueue == null) return NotFound($"Queue with Id = {id} not found");

            _queueService.Update(id, queue);

            return NoContent();
        }

        // DELETE Queue
        [HttpDelete("{id}")]
        public ActionResult<Queue> Delete(string id)
        {
            var existingQueue = _queueService.Get(id);

            if (existingQueue == null) return NotFound($"Queue with Id = {id} not found");

            _queueService.Remove(existingQueue.Id);

            return Ok($"Queue with ID = {id} deleted");
        }
    }
}
