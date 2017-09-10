using BloggerDocuments.Products;

namespace BloggerDocuments.Prices
{
    public class ProductPrice
    {
        public ProductId ProductId { get; }

        public decimal Value { get; }

        public ProductPrice(ProductId productId, decimal value)
        {
            ProductId = productId;
            Value = value;
        }
    }
}