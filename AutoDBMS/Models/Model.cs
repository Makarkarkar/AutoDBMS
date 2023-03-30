using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AutoDBMS;

public partial class Model
{
    [JsonIgnore]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string? ObjectId { get; set; }
    
    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("year")]
    public int? Year { get; set; }

    [BsonElement("brand_id")]
    public int? BrandId { get; set; }

    [JsonIgnore]
    [BsonIgnore]
    public virtual Brand? Brand { get; set; }
    
    [BsonElement("vehicles")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
