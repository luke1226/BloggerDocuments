using System;
using System.Collections.Generic;
using BloggerDocuments.Products;
using BloggerDocuments.Tests.Assemblers;
using BloggerDocuments.Tests.Environment.Mocks;
using BloggerDocuments.Tests.Mocks;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment.Tables
{
    public class ProductsTable
    {
        private readonly ITestMocks _mocks;
        private readonly Dictionary<string, Product> _products;
        private int _currentProductId;

        public ProductsTable(ITestMocks mocks)
        {
            _mocks = mocks;
            _products = new Dictionary<string, Product>();
        }

        public ProductsTable AddOrUpdate(string name, Action<ProductAssembler> product)
        {
            _currentProductId++;

            var productObj = TestProducts.Product(_currentProductId, name);
            var productAssembler = new ProductAssembler();
            product(productAssembler);

            if (_products.ContainsKey(name))
                _products.Remove(name);

            _products.Add(name, productObj);

            _mocks.PriceService.GetPrice(productObj.Info.Id).Returns(productAssembler.Price);

            return this;
        }

        public Product Get(string name, Action<ProductAssembler> product)
        {
            _currentProductId++;

            var productObj = TestProducts.Product(_currentProductId, name);
            var productAssembler = new ProductAssembler();
            product(productAssembler);

            _mocks.PriceService.GetPrice(productObj.Info.Id).Returns(productAssembler.Price);

            return productObj;
        }

        public Product Get(string name)
        {
            if (_products.ContainsKey(name))
                return _products[name];

            return Get(name, p => { });
        }
    }
}