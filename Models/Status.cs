
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FuelQueue.Models
{
    [BsonIgnoreExtraElements]
    public class Status
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        [BsonElement("stationName")]
        public string stationName { get; set; } = null!;

        [BsonElement("stationNo")]
        public string stationNo { get; set; } = null!;

        [BsonElement("stationOwnerName")]
        public string stationOwnerName { get; set; } = null!;

        [BsonElement("startTime")]
        public string startTime { get; set; } = null!;

        [BsonElement("endTime")]
        public string endTime { get; set; } = null!;

        [BsonElement("date")]
        public string date { get; set; } = null!;
        [BsonElement("fuelType")]
        public string fuelType { get; set; } = null!;

        [BsonElement("availability")]
        public string availability { get; set; } = null!;
    }
}
