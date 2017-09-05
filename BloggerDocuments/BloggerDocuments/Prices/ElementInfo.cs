namespace BloggerDocuments.Prices
{
    public class ElementInfo
    {
        public ProductId ProductId { get; }

        public decimal Quantity { get; }

        public ElementInfo(ProductId productId, decimal quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
