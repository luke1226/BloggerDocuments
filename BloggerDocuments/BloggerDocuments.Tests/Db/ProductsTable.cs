using System;
using BloggerDocuments.Prices;
using BloggerDocuments.Products;
using BloggerDocuments.Tests.Assemblers;
using BloggerDocuments.Tests.Mocks;
using NSubstitute;

namespace BloggerDocuments.Tests.Db
{
    internal class ProductsTable
    {
        private readonly TestDbObject _object;

        public ProductsTable(TestDbObject @object)
        {
            _object = @object;
        }

        public Product Add(string name, Action<ProductAssembler> product)
        {
            var productObj = TestProducts.Product(name);

            var productAssembler = new ProductAssembler();

            product(productAssembler);

            _object.Products.Add(name, productObj);
            _object.Prices.Add(
                name,
                new ProductPrice(productObj.Id, productAssembler.Price));

            _object.PriceService.GetPrice(productObj.Id.Value).Returns(productAssembler.Price);

            return productObj;
        }
    }
}