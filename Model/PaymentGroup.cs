using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace moneygoes.Models
{
    public class PaymentGroup
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public List<PaymentItem> Items { get; set; } = new List<PaymentItem>();
        public DateTime Created { get; set; } = DateTime.Now;
    }
}