using System.Collections.Generic;
using BloggerDocuments.Prices;
using BloggerDocuments.Tests.Db;
using BloggerDocuments.Tests.Mocks;
using Xunit;
using Assert = Xunit.Assert;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    public class PriceCalculator_CalculateTest
    {
        [Fact]
        public void ShouldReturnProperPricingPlanWhenProductsInBundle()
        {
            //Arrange
            var db =
                TestDb.Add(
                    c =>
                    {
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(5));
                        c.Products.Add("A3", p => p.WithPrice(1));

                        c.DiscountStructure.Add(d => d.AddProduct("A1", 0.1m).AddProduct("A2", 0.1m));
                        c.DiscountStructure.Add(d => d.AddProduct("A1", 0.5m).AddProduct("A3", 0.5m));
                    });

            var priceCalculator = new PriceCalculator(db.PriceService, db.DiscountsService);
            var elements =
                new List<ElementInfo>()
                {
                    db.ElementInfos.Get("A2"),
                    db.ElementInfos.Get("A1")
                };

            var expectedPrices =
                new List<ElementPrice>()
                {
                    TestElementPrices.Get(db.ElementInfos.Get("A1"), 9m),
                    TestElementPrices.Get(db.ElementInfos.Get("A2"), 4.5m)
                };


            //Act
            var pricingPlan = priceCalculator.Calculate(elements);


            //Assert
            Assert.Equal(2, pricingPlan.Prices.Count);
            Assert.Equal(expectedPrices, pricingPlan.Prices, new PricesComparer());
        }

        [Fact]
        public void ShouldReturnProperPricingPlanWhenProductsInSecondBundle()
        {
            //Arrange
            var db =
                TestDb.Add(
                    c =>
                    {
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(5));
                        c.Products.Add("A3", p => p.WithPrice(2));
                        c.Products.Add("A4", p => p.WithPrice(1));

                        c.DiscountStructure.Add(d => d.AddProduct("A1", 0.1m).AddProduct("A2", 0.1m));
                        c.DiscountStructure.Add(d => d.AddProduct("A1", 0.1m).AddProduct("A3", 0.5m).AddProduct("A4", 0.5m));
                    });

            var priceCalculator = new PriceCalculator(db.PriceService, db.DiscountsService);
            var elements =
                new List<ElementInfo>()
                {
                    db.ElementInfos.Get("A1"),
                    db.ElementInfos.Get("A4"),
                    db.ElementInfos.Get("A3")
                };

            var expectedPrices =
                new List<ElementPrice>()
                {
                    TestElementPrices.Get(db.ElementInfos.Get("A1"), 9m),
                    TestElementPrices.Get(db.ElementInfos.Get("A3"), 1m),
                    TestElementPrices.Get(db.ElementInfos.Get("A4"), 0.5m),
                };


            //Act
            var pricingPlan = priceCalculator.Calculate(elements);


            //Assert
            Assert.Equal(3, pricingPlan.Prices.Count);
            Assert.Equal(expectedPrices, pricingPlan.Prices, new PricesComparer());
        }

        [Fact]
        public void ShouldReturnProperPricingPlanWhenProductsNotInBundle()
        {
            //Arrange
            var db =
                TestDb.Add(
                    c =>
                    {
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(5));
                        c.Products.Add("A3", p => p.WithPrice(1));

                        c.DiscountStructure.Add(d => d.AddProduct("A1", 0.1m).AddProduct("A2", 0.1m).AddProduct("A3", 0.2m));
                        c.DiscountStructure.Add(d => d.AddProduct("A1", 0.5m).AddProduct("A3", 0.5m));
                    });

            var priceCalculator = new PriceCalculator(db.PriceService, db.DiscountsService);
            var elements =
                new List<ElementInfo>()
                {
                    db.ElementInfos.Get("A1"),
                    db.ElementInfos.Get("A2")
                };

            var expectedPrices =
                new List<ElementPrice>()
                {
                    TestElementPrices.Get(db.ElementInfos.Get("A1"), 10),
                    TestElementPrices.Get(db.ElementInfos.Get("A2"), 5)
                };


            //Act
            var pricingPlan = priceCalculator.Calculate(elements);


            //Assert
            Assert.Equal(2, pricingPlan.Prices.Count);
            Assert.Equal(expectedPrices, pricingPlan.Prices, new PricesComparer());
        }
    }
}
