using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace libraryAPI.Models
{
    public class Borrower {
        public string Id { get; set;}
        public string Name { get; set; }
        public string StartDate { get; set; } 
        public string EndDate { get; set; }
    }
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public bool InStock { get; set; }
        public List<Borrower> BorrowerList { get; set; }

    }
}