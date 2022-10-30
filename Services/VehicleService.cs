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
    public class VehicleService
    {
          private readonly IMongoCollection<Vehicle> _vehicle;

        public VehicleService(IOptions<MongoDBSettings> mongoDBSettings)
        {
           MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
           IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
           _vehicle = database.GetCollection<Vehicle>(mongoDBSettings.Value.VehicleCollectionName);
        }

         public Vehicle Create(Vehicle vehicle)
        {
            _vehicle.InsertOne(vehicle);
            return vehicle;
        }

        public List<Vehicle> Get()
        {
            return _vehicle.Find(vehicle => true).ToList();
        }

        public Vehicle Get(string id)
        {
            return _vehicle.Find(vehicle => vehicle.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _vehicle.DeleteOne(vehicle => vehicle.Id == id);
        }

        public void Update(string id, Vehicle vehicle)
        {
            _vehicle.ReplaceOne(vehicle => vehicle.Id == id, vehicle);
        }

     

        
        
    }
}