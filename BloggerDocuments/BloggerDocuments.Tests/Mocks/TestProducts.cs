using BloggerDocuments.Products;

namespace BloggerDocuments.Tests.Mocks
{
    class TestProducts
    {
        public static Product Product(int id, string name)
        {
            var product =
                new Product(new ProductInfo(id, name), name);

            return product;
        }
    }
}
