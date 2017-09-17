using BloggerDocuments.Prices;
using BloggerDocuments.Products;

namespace BloggerDocuments.Tests.Mocks
{
    class TestPrices
    {
        public static ProductPrice Get(Product product, decimal value)
        {
            return new ProductPrice(product.Id, value);
        }
    }
}
