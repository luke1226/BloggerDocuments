using BloggerDocuments.Prices;
using BloggerDocuments.Products;

namespace BloggerDocuments.Tests.Mocks
{
    class TestPrices
    {
        public static ProductPrice Get(string productName, decimal value)
        {
            return new ProductPrice(new ProductId(productName), value);
        }
    }
}
