using System;
using System.Collections.Generic;
using DataAccess.MongoDB.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.MongoDB.Models
{

    public class SubCategories: IEntityBase
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string categoryId { get; set; }

        public string name { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }

    }
}
