using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FuelQueue.Models;

public class Vehicle {
    [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        [BsonElement("vehicleNo")]
        public string vehicleNo { get; set; } = null!;

        [BsonElement("vehicleType")]
        public string vehicleType { get; set; } = null!;

        [BsonElement("chassisNo")]
        public string chassisNo { get; set; } = null!;

        [BsonElement("password")]
        public string password { get; set; } = null!;

        [BsonElement("confirmPassword")]
        public string confirmPassword { get; set; } = null!;
}