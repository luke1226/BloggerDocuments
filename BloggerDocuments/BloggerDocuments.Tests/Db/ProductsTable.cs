using System;
using System.Collections.Generic;
using BloggerDocuments.Tests.Assemblers;
using NSubstitute;

namespace BloggerDocuments.Tests.Db
{
    internal class ProductsTable
    {
        private static readonly TestMocks Mocks = TestMocks.Instance;

        private static readonly Dictionary<string, Product> Products = new Dictionary<string, Product>();

        public Product Get(string name, Action<ProductAssembler> product)
        {
            if (Products.ContainsKey(name))
                return Products[name];

            var productObj = TestProducts.Product(name);
            var productAssembler = new ProductAssembler();

            product(productAssembler);

            Products.Add(name, productObj);

            Mocks.PriceService.GetPrice(productObj.Id).Returns(productAssembler.Price);

            return productObj;
        }

        public Product Get(string name)
        {
            return Get(name, p => { });
        }
    }
}