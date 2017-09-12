namespace BloggerDocuments.Database.Entities
{
    public class SalesOrderItemEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }

        public decimal NetValue { get; set; }
    }
}