using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FuelQueue.Models;

public class FuelStation {
    [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        [BsonElement("stationName")]
        public string StationName { get; set; } = null!;
        [BsonElement("stationNo")]
        public string StationNo { get; set; } = null!;

        [BsonElement("stationOwnerName")]
        public string StationOwnerName { get; set; } = null!;
        [BsonElement("stationOwnerEmail")]
        public string StationOwnerEmail { get; set; } = null!;
        [BsonElement("password")]
        public string Password { get; set; } = null!;
        [BsonElement("confirmPassword")]
        public string ConfirmPassword { get; set; } = null!;
   
}
