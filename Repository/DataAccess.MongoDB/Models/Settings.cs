using System;
using System.Collections.Generic;
using DataAccess.MongoDB.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.MongoDB.Models
{
    public class Settings : IEntityBase
    {
        public Settings()
        {
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public List<Sizes> sizes { get; set; }
        public List<Colors> colors { get; set; }
        public List<Genders> genders { get; set; }
  
    }

    public class Sizes : IItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool active { get; set; }
    }

    public class Colors : IItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool active { get; set; }
    }


    public class Genders : IItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool active { get; set; }
    }

}
