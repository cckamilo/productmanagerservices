using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.MongoDB.Models
{

    public class SubCategories
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string name { get; set; }

        public List<Items> genders { get; set; }

        public List<Items> sizes { get; set; }

        public List<Items> colors { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }

    }
}
