using BYS.Mobile.API.Shared.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BYS.Mobile.API.Shared.Models
{
    public class BaseMongoEntity : IBaseEntity<string>
    {
        [BsonElement("_id")]
        [JsonIgnore]
        public ObjectId ObjectId
        {
            get => ObjectId.Parse(Id);
            set => Id = value.ToString();
        }
        [BsonIgnore]
        [JsonProperty("_id")]
        public virtual string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }

        public virtual string GenerateNewId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}
