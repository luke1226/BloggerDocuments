using BloggerDocuments.Tests.Environment;
using Xunit;

namespace BloggerDocuments.Tests.FactoriesTests
{
    public class ReceiptFactory_AddItem_PricingPlanTest : TestClassWithEnvironment
    {
        [Fact]
        public void ShouldReturnPricingPlanForAllItemsInNewMode()
        {
            //Arrange
            var env =
                TestEnvironment.Create(
                    c =>
                    {
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(50));
                    });

            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.New();


            //Act
            receipt.AddItem(env.Products["A1"]);
            receipt.AddItem(env.Products["A2"]);


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
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(50));

                        c.Documents.AddSalesOrder(
                            doc =>
                            {
                                doc.WithItems(
                                    itemsContext =>
                                    {
                                        itemsContext.Add("A1", 5, 1);
                                    });
                            });
                    });

            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.GenerateFromSalesOrder(env.SalesOrderEntities[0]);


            //Act
            receipt.AddItem(env.Products["A2"]);


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
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(5));

                        c.Documents.AddSalesOrder(
                            doc =>
                            {
                                doc.WithItems(
                                    itemsContext =>
                                    {
                                        itemsContext.Add("A1", 5, 1);
                                        itemsContext.Add("A2", 2, 1);
                                    });
                            });
                    });

            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.GenerateFromSalesOrder(env.SalesOrderEntities[0]);


            //Act
            receipt.AddItem(env.Products["A2"]);


            //Assert
            Assert.Equal(12, receipt.Value);
        }
    }
}
