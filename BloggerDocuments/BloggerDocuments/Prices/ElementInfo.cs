using BloggerDocuments.Documents;
using BloggerDocuments.Products;

namespace BloggerDocuments.Prices
{
    public class ElementInfo
    {
        public ProductInfo ProductInfo { get; }

        public ItemId ItemId { get; set; }

        public decimal Quantity { get; }

        public ElementInfo(ProductInfo productInfo, ItemId itemId, decimal quantity)
        {
            ProductInfo = productInfo;
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
