using FuelQueue.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace FuelQueue.Services
{
    public class QueueService 
    {
        private readonly IMongoCollection<Queue> _queueCollection;

        public QueueService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
           IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
           _queueCollection = database.GetCollection<Queue>(mongoDBSettings.Value.QueueCollectionName);
        }
        public Queue Create(Queue queue)
        {
            _queueCollection.InsertOne(queue);
            return queue;
        }

        public List<Queue> Get()
        {
            return _queueCollection.Find(queue => true).ToList();
        }

        public Queue Get(string id)
        {
            return _queueCollection.Find(queue => queue.Id == id).FirstOrDefault();
        }

        public List<Queue> GetByStation(string name)
        {
            return _queueCollection.Find(queue => queue.StationName == name).ToList();
        }

        public void Remove(string id)
        {
            _queueCollection.DeleteOne(queue => queue.Id == id);
        }

        public void Update(string id, Queue queue)
        {
            _queueCollection.ReplaceOne(queue => queue.Id == id, queue);
        }
    }
}
