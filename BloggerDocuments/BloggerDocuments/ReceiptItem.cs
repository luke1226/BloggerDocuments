namespace BloggerDocuments
{
    class ReceiptItem
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }

        public ReceiptItem(Product product, decimal quantity)
        {
            Name = product.Name;
            Price = product.Price;
            Quantity = quantity;
            Value = Price * Quantity;
        }
    }
}
