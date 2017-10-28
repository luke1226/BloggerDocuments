using System.Collections.Generic;

namespace BloggerDocuments.Database.Entities
{
    public class ReceiptEntity
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public List<ReceiptItemEntity> Items { get; set; }
    }
}
