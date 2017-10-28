using BloggerDocuments.Documents;
using BloggerDocuments.Products;

namespace BloggerDocuments.Prices
{
    public class ElementPrice
    {
        public ItemId ItemId { get; }

        public ProductInfo ProductInfo { get; }

        public decimal Value { get; }

        public ElementPrice(ItemId itemId, ProductInfo productInfo, decimal value)
        {
            ItemId = itemId;
            ProductInfo = productInfo;
            Value = value;
        }
    }
}