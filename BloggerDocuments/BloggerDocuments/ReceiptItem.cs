using System;

namespace BloggerDocuments
{
    class ReceiptItem
    {
        public Guid ProductId { get; set; }

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
    }
}
