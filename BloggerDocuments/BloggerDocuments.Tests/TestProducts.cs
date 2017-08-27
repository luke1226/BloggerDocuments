using System;
using NSubstitute;

namespace BloggerDocuments.Tests
{
    class TestProducts
    {
        private static readonly TestMocks Mocks = TestMocks.Instance;

        public static Product Product(string name, decimal price, decimal quantity = 1)
        {
            var product =
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };

            Mocks.PriceService.GetPrice(product.Id).Returns(price);

            return product;
        }
    }
}
