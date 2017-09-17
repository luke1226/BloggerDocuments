using BloggerDocuments.Database.Entities;
using BloggerDocuments.Products;

namespace BloggerDocuments.Documents
{
    public class ReceiptItem
    {
        public ProductId ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }

        public ReceiptItem(Product product, decimal quantity)
        {
            ProductId = product.Id;
            Name = product.Name;
            Quantity = quantity;
        }

        public ReceiptItem(SalesOrderItemEntity entity)
        {
            ProductId = entity.ProductId;
            Name = entity.ProductName;
            Price = entity.Price;
            Quantity = entity.Quantity;
            Value = entity.Value;
        }
    }
}
