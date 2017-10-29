using System;
using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Tests.Assemblers;

namespace BloggerDocuments.Tests.Environment.Tables
{
    public class DiscountStructureTable
    {
        private readonly ProductsTable _productsTable;
        private readonly List<BundleInfo> _discountStructure;

        public DiscountStructureTable(ProductsTable productsTable)
        {
            _productsTable = productsTable;
            _discountStructure = new List<BundleInfo>();
        }

        public void Add(Action<BundleInfoAssembler> discount)
        {
            var dia = new BundleInfoAssembler(_productsTable);
            discount(dia);
            var di = dia.Build();
            _discountStructure.Add(di);
        }

        public List<BundleInfo> GetDiscountInfos()
        {
            return _discountStructure;
        }
    }
}