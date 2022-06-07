using System;

namespace DataAccess.MongoDB.Interfaces
{
    public interface IItems
    {

        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool active { get; set; }
    }
}
