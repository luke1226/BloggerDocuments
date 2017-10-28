using BloggerDocuments.Database.Entities;
using BloggerDocuments.Products;

namespace BloggerDocuments.Documents
{
    public class ReceiptItem
    {
        public ProductInfo ProductInfo { get; set; }

        public ItemId ItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }

        public ReceiptItem(Product product, decimal quantity)
        {
            ProductInfo = product.Info;
            ItemId = ItemId.New();
            Name = product.Name;
            Quantity = quantity;
        }

        public ReceiptItem(SalesOrderItemEntity entity)
        {
            ProductInfo = entity.ProductInfo;
            ItemId = ItemId.New();
            Name = entity.ProductName;
            Price = entity.Price;
            Quantity = entity.Quantity;
            Value = entity.Value;
        }
    }
}
