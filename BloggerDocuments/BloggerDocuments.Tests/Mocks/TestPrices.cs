using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.Mocks
{
    class TestPrices
    {
        public static Price Get(string productName, decimal value)
        {
            return new Price()
            {
                ProductId = new ProductId(productName),
                Value = value
            };
        }
    }
}
