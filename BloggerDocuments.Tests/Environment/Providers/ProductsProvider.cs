using System;
using BloggerDocuments.Products;
using BloggerDocuments.Tests.Assemblers;
using BloggerDocuments.Tests.Environment.Tables;

namespace BloggerDocuments.Tests.Environment.Providers
{
    public class ProductsProvider
    {
        private readonly ProductsTable _productsTable;

        public ProductsProvider(ProductsTable productsTable)
        {
            _productsTable = productsTable;
        }

        public Product Get(string name, Action<ProductAssembler> product)
        {
            return _productsTable.Get(name, product);
        }

        public Product Get(string name)
        {
            return _productsTable.Get(name);
        }
    }
}
