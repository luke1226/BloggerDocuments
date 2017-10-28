using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Documents;
using BloggerDocuments.Prices;
using BloggerDocuments.Products;
using NSubstitute;
using Xunit;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    public class PriceOnlyForNewElementCalculator_CalculateTest
    {
        [Fact]
        public void ShouldCorrectlyFilterItemsAndPassToCalculate()
        {
            //Arrange
            var elementInfos = new List<ElementInfo>()
            {
                GetElement("A1"),
                GetElement("A2"),
                GetElement("A3"),
                GetElement("A4")
            };

            List<ElementInfo> filteredElementInfoList = null;
            var priceCalculatorInternal = Substitute.For<IPriceCalculator>();
            priceCalculatorInternal.When(x => x.Calculate(Arg.Any<IEnumerable<ElementInfo>>()))
                .Do(ci =>
                {
                    var arg = (IEnumerable<ElementInfo>)ci.Args()[0];
                    filteredElementInfoList = arg.ToList();
                });

            var itemIds = new List<ItemId>()
            {
                elementInfos.First(x => x.ProductInfo.Code == "A1").ItemId,
                elementInfos.First(x => x.ProductInfo.Code == "A4").ItemId
            };

            var priceCalculator = new PriceOnlyForNewElementCalculator(priceCalculatorInternal, itemIds);

            var expectedElementInfoList = new List<ElementInfo>()
            {
                elementInfos.First(x => x.ProductInfo.Code == "A2"),
                elementInfos.First(x => x.ProductInfo.Code == "A3")
            };


            //Act
            priceCalculator.Calculate(elementInfos);


            //Assert
            Assert.Equal(expectedElementInfoList, filteredElementInfoList, new ElementInfoComparer());
        }

        private int _elementInfoId;
        private ElementInfo GetElement(string name)
        {
            _elementInfoId++;

            return
                new ElementInfo(
                    new ProductInfo(_elementInfoId, name),
                    ItemId.New(),
                    1);
        }
    }
}
