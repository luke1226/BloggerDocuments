using System.Collections.Generic;

namespace BloggerDocuments.Database.Entities
{
    public class SalesOrderEntity
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public List<SalesOrderItemEntity> Items { get; set; }
    }
}
