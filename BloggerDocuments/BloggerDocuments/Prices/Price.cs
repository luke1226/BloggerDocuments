using System;

namespace BloggerDocuments.Prices
{
    public class Price
    {
        public Guid ProductId { get; set; }

        public decimal Value { get; set; }
    }
}