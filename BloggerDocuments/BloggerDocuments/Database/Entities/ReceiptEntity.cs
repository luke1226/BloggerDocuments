using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerDocuments.Database.Entities
{
    public class ReceiptEntity
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public decimal NetValue { get; set; }
    }
}
