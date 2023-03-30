using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoDBMS;

public partial class Brand
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonIgnore]
    public string? ObjectId { get; set; }
    
    [BsonElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [BsonElement("country")]
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    //[BsonIgnore]
    [BsonElement("models")]
    public virtual ICollection<Model> Models { get; set; }
}
