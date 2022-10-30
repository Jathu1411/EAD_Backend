using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuelQueue.Models
{
    [BsonIgnoreExtraElements]
    public class Queue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } =null!;

        [BsonElement("vehicleNo")]
        public string VehicleNo { get; set; } = null!;

        [BsonElement("vehicleType")]
        public string VehicleType { get; set; } = null!;

        [BsonElement("stationId")]
        public string StationId { get; set; } = null!;

        [BsonElement("stationName")]
        public string StationName { get; set; } = null!;

        [BsonElement("arrivalTime")]
        public string ArrivalTime { get; set; } = null!;

        [BsonElement("departTime")]
        public string DepartureTime { get; set; } = null!;

        [BsonElement("pumpStatus")]
        public string PumpStatus { get; set; } = null!;
    }
}
