using System;
using System.Collections.Generic;
using DataAccess.MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.MongoDB.Interfaces
{
    public interface IItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public List<GroupItems> items { get; set; }
        public bool active { get; set; }

    }
}
