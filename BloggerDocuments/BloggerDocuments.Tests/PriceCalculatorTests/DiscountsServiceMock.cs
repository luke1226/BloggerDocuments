using System;
using System.Collections.Generic;
using BloggerDocuments.Prices;
using BloggerDocuments.Tests.Assemblers;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class DiscountsServiceMock : IDiscountsService
    {
        private readonly List<DiscountInfo> _discountStructure;

        public DiscountsServiceMock()
        {
            _discountStructure =
                new List<DiscountInfo>()
                {
                    NewDiscount(d => d.AddProduct("A1", 10, 0.1m).AddProduct("A2", 5, 0.1m).AddProduct("A4", 5, 0.1m)),
                    NewDiscount(d => d.AddProduct("A1", 10, 0.5m).AddProduct("A3", 5, 0.5m))
                };
        }

        public List<DiscountInfo> GetDiscountStructure()
        {
            return _discountStructure;
        }

        private DiscountInfo NewDiscount(Action<DiscountInfoAssembler> discount)
        {
            var dia = new DiscountInfoAssembler();
            discount(dia);
            var di = dia.Build();
            return di;
        }
    }
}
