using System;

namespace BloggerDocuments.Tests
{
    class TestProducts
    {
        public static Product Product(string name)
        {
            var product =
                new Product(Guid.NewGuid(), name);

            return product;
        }
    }
}
