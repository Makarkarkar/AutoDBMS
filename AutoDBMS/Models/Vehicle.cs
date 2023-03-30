using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoDBMS;

public partial class Vehicle
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonIgnore]
    public string? ObjectId { get; set; }
    
    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("reg_number")]
    public string? RegNumber { get; set; }

    [BsonElement("owner_email")]
    public string? OwnerEmail { get; set; }

    [BsonElement("model_id")]
    public int? ModelId { get; set; }

    [JsonIgnore]
    public virtual Model? Model { get; set; }
}
