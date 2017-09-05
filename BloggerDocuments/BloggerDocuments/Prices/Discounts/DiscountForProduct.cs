namespace BloggerDocuments.Prices.Discounts
{
    public class DiscountForProduct
    {
        public ProductId ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }
    }
}