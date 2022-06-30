using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shell.API.Data.Entities
{
    public class PageInfo
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PageName { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
    }
}
