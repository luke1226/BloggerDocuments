using BloggerDocuments.Products;

namespace BloggerDocuments.Tests.Mocks
{
    class TestProducts
    {
        public static Product Product(int id, string name)
        {
            var product =
                new Product(new ProductId(id), name);

            return product;
        }
    }
}
