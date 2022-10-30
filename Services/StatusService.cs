using FuelQueue.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FuelQueue.Services
{
    public class StatusService
    {
          private readonly IMongoCollection<Status> _statusCollection;

        public StatusService(IOptions<MongoDBSettings> mongoDBSettings)
        {
           MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
           IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
           _statusCollection = database.GetCollection<Status>(mongoDBSettings.Value.StatusCollectionName);
        }

          public Status Create(Status status)
        {

            _statusCollection.InsertOne(status);
            return status;
        }

        public List<Status> Get()
        {
            return _statusCollection.Find(status => true).ToList();
        }

        public List<Status> GetByStation(string name)
        {
            return _statusCollection.Find(status => status.stationName == name).ToList();
        }

        public Status Get(string id)
        {
            return _statusCollection.Find(status => status.Id == id).FirstOrDefault();
        }

        public Status GetByDate(string date)
        {
            return _statusCollection.Find(status => status.date == date).FirstOrDefault();
        }

        public Status GetByType(string type)
        {
            return _statusCollection.Find(status => status.fuelType == type).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _statusCollection.DeleteOne(status => status.Id == id);
        }

        public void Update(string id, Status status)
        {
            _statusCollection.ReplaceOne(status => status.Id == id, status);
        }

        
        
    }
}