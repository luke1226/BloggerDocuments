using System;

namespace BloggerDocuments
{
    class TestProducts
    {
        public static Product Product(string name, decimal price, decimal quantity = 1)
        {
            return
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Price = price
                };
        }
    }
}
