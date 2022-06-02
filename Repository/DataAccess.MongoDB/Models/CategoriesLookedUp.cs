using System;
using System.Collections.Generic;

namespace DataAccess.MongoDB.Models
{
    public class CategoriesLookedUp 
    {

        public string id { get; set; }

        public string name { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }

        public IEnumerable<Categories> categories { get; set; }
    }
}
 