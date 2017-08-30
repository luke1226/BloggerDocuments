using System;
using System.Collections.Generic;
using BloggerDocuments.Prices;
using BloggerDocuments.Tests.Db;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    public class PriceCalculator_CalculateTest
    {
        [Fact]
        public void ShouldReturnProperPriceList()
        {
            //Arrange
            var priceCalculator = new PriceCalculator(TestMocks.Instance.PriceService, new DiscountsServiceMock());
            var newProduct = TestDb.Products.Get("A1");
            var existingProducts =
                new List<Product>()
                {
                    TestDb.Products.Get("A2")
                };

            var expectedPrices =
                new List<Price>()
                {
                    new Price() {Product = newProduct, Value = 9},
                    new Price() {Product = existingProducts[0], Value = 4.5m}
                };


            //Act
            var pricingPlan = priceCalculator.Calculate(newProduct, 1, existingProducts);


            //Assert
            Assert.Equal(2, pricingPlan.Prices.Count);
            CollectionAssert.AreEquivalent(expectedPrices, pricingPlan.Prices);
        }
    }
}
