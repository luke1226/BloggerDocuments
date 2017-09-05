namespace BloggerDocuments.Tests.Mocks
{
    class TestProducts
    {
        public static Product Product(string name)
        {
            var product =
                new Product(new ProductId(name), name);

            return product;
        }
    }
}
