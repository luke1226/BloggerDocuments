using System;
using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Tests.Assemblers;

namespace BloggerDocuments.Tests.Db
{
    internal class DiscountStructureTable
    {
        private readonly TestDbObject _object;
        private readonly List<BundleInfo> _discountStructure;

        public DiscountStructureTable(TestDbObject @object)
        {
            _object = @object;
            _discountStructure = new List<BundleInfo>();
        }

        public void Add(Action<DiscountInfoAssembler> discount)
        {
            var dia = new DiscountInfoAssembler(_object.Products);
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