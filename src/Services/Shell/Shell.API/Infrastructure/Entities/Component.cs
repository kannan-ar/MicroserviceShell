using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shell.API.Infrastructure.Entities
{
    public class Component
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RemoteName { get; set; }
        public string RemoteEndpoint { get; set; }
        public string ComponentName { get; set; }
        public bool RequireAuthentication { get; set; }
    }
}
