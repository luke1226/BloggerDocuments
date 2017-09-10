using BloggerDocuments.Products;

namespace BloggerDocuments.Prices.Discounts
{
    public class ProductDiscount
    {
        public ProductId ProductId { get; }

        public decimal Quantity { get; }

        public decimal Value { get; }

        public ProductDiscount(ProductId productId, decimal quantity, decimal value)
        {
            ProductId = productId;
            Quantity = quantity;
            Value = value;
        }
    }
}