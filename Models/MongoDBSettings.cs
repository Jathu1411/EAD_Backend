namespace FuelQueue.Models
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string FuelCollectionName { get; set; } = null!;
        public string FuelStationCollectionName { get; set; } = null!;
        public string ShedOwnerCollectionName { get; set; } = null!;
        public string QueueCollectionName { get; set; } = null!;
        public string StatusCollectionName { get; set; } = null!;
        public string VehicleCollectionName { get; set; } = null!;
    }
}