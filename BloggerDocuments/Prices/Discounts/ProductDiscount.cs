using BloggerDocuments.Products;

namespace BloggerDocuments.Prices.Discounts
{
    public class ProductDiscount
    {
        public ProductInfo ProductInfo { get; }

        public decimal Quantity { get; }

        public decimal Value { get; }

        public ProductDiscount(ProductInfo productInfo, decimal quantity, decimal value)
        {
            ProductInfo = productInfo;
            Quantity = quantity;
            Value = value;
        }
    }
}