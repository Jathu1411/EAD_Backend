using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelQueue.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace FuelQueue.Services
{
    public class FuelStationService
    {
          private readonly IMongoCollection<FuelStation> _fuelStationCollection;

        public FuelStationService(IOptions<MongoDBSettings> mongoDBSettings)
        {
           MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
           IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
           _fuelStationCollection = database.GetCollection<FuelStation>(mongoDBSettings.Value.FuelStationCollectionName);
        }

       public FuelStation Create(FuelStation station)
        {
            _fuelStationCollection.InsertOne(station);
            return station;
        }

        public List<FuelStation> Get()
        {
            return _fuelStationCollection.Find(station => true).ToList();
        }

        public FuelStation Get(string id)
        {
            return _fuelStationCollection.Find(station => station.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _fuelStationCollection.DeleteOne(station => station.Id == id);
        }

        public void Update(string id, FuelStation station)
        {
            _fuelStationCollection.ReplaceOne(station => station.Id == id, station);
        }
    }
}