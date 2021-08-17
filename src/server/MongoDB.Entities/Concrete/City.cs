using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Entities.Concrete
{

    public  class City : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
    }
}
