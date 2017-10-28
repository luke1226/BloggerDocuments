using System;
using BloggerDocuments.Products;
using BloggerDocuments.Tests.Assemblers;
using BloggerDocuments.Tests.Mocks;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment.Tables
{
    public class ProductsTable
    {
        private readonly TestEnvironmentObject _object;
        private int _currentProductId;

        public ProductsTable(TestEnvironmentObject @object)
        {
            _object = @object;
        }

        public Product Add(string name, Action<ProductAssembler> product)
        {
            _currentProductId++;

            var productObj = TestProducts.Product(_currentProductId, name);

            var productAssembler = new ProductAssembler();

            product(productAssembler);

            _object.Products.Add(name, productObj);
            //_object.Prices.Add(
            //    name,
            //    new ElementPrice(productObj.Id, productAssembler.Price));

            _object.PriceService.GetPrice(productObj.Info.Id).Returns(productAssembler.Price);

            return productObj;
        }
    }
}