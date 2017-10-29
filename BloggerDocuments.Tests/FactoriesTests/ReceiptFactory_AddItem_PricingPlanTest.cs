using System.Linq;
using BloggerDocuments.Tests.Environment;
using Xunit;

namespace BloggerDocuments.Tests.FactoriesTests
{
    public class ReceiptFactory_AddItem_PricingPlanTest : TestClassBase
    {
        [Fact]
        public void ShouldReturnPricingPlanForAllItemsInNewMode()
        {
            //Arrange
            var env =
                TestEnvironment.Create(
                    c =>
                    {
                        c.Products.AddOrUpdate("A1", p => p.WithPrice(10));
                        c.Products.AddOrUpdate("A2", p => p.WithPrice(50));
                    });

            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.New();


            //Act
            receipt.AddItem(env.Products.Get("A1"));
            receipt.AddItem(env.Products.Get("A2"));


            //Assert
            Assert.Equal(60, receipt.Value);
        }

        [Fact]
        public void ShouldReturnPricingPlanForOnlyNewItemsInGenerateFromReceiptMode()
        {
            //Arrange
            var env =
                TestEnvironment.Create(
                    c =>
                    {
                        c.Products.AddOrUpdate("A1", p => p.WithPrice(10));
                        c.Products.AddOrUpdate("A2", p => p.WithPrice(50));

                        c.Documents
                            .AddSalesOrder(doc => doc
                                .WithItems(itemsContext => itemsContext.Add("A1", 5, 1)));
                    });

            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.GenerateFromSalesOrder(env.SalesOrderEntities.First());


            //Act
            receipt.AddItem(env.Products.Get("A2"));


            //Assert
            Assert.Equal(55, receipt.Value);
        }

        [Fact]
        public void ShouldReturnPricingPlanForOnlyNewItemsInGenerateFromReceiptModeWhenSameProductsAdded()
        {
            //Arrange
            var env =
                TestEnvironment.Create(
                    c =>
                    {
                        c.Products.AddOrUpdate("A1", p => p.WithPrice(10));
                        c.Products.AddOrUpdate("A2", p => p.WithPrice(5));

                        c.Documents
                            .AddSalesOrder(doc => doc
                                .WithItems(itemsContext => itemsContext
                                    .Add("A1", 5, 1)
                                    .Add("A2", 2, 1)));
                    });


            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.GenerateFromSalesOrder(env.SalesOrderEntities.First());


            //Act
            receipt.AddItem(env.Products.Get("A2"));


            //Assert
            Assert.Equal(12, receipt.Value);
        }
    }
}
