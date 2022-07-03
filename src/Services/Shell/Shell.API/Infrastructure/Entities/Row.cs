using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Shell.API.Infrastructure.Entities
{
    public class Row
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int RowIndex { get; set; }
        public string PageName { get; set; }
        public ICollection<Column> Columns { get; set; }
    }
}
