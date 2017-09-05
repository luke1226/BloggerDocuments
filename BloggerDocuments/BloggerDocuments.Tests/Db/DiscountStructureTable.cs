using System;
using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Tests.Assemblers;

namespace BloggerDocuments.Tests.Db
{
    internal class DiscountStructureTable
    {
        private readonly TestDbObject _object;
        private readonly List<DiscountInfo> _discountStructure;

        public DiscountStructureTable(TestDbObject @object)
        {
            _object = @object;
            _discountStructure = new List<DiscountInfo>();
        }

        public void Add(Action<DiscountInfoAssembler> discount)
        {
            var dia = new DiscountInfoAssembler(_object.Products);
            discount(dia);
            var di = dia.Build();
            _discountStructure.Add(di);
        }

        public List<DiscountInfo> GetDiscountInfos()
        {
            return _discountStructure;
        }
    }
}