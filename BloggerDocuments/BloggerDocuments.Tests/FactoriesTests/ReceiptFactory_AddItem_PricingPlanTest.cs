using BloggerDocuments.Factories;
using BloggerDocuments.Tests.Db;
using Xunit;

namespace BloggerDocuments.Tests.FactoriesTests
{
    public class ReceiptFactory_AddItem_PricingPlanTest
    {
        [Fact]
        public void ShouldReturnPricingPlanForAllItemsInNewMode()
        {
            //Arrange
            var db =
                TestDb.Add(
                    c =>
                    {
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(50));
                    });

            var receiptFactory = new ReceiptFactory()
            {
                PriceService = db.PriceService,
                DiscountsService = db.DiscountsService
            };

            var receipt = receiptFactory.New();


            //Act
            receipt.AddItem(db.Products["A1"]);
            receipt.AddItem(db.Products["A2"]);


            //Assert
            Assert.Equal(60, receipt.Value);
        }

        [Fact]
        public void ShouldReturnPricingPlanForOnlyNewItemsInGenerateFromReceiptMode()
        {
            //Arrange
            var db =
                TestDb.Add(
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

            var receiptFactory = new ReceiptFactory()
            {
                PriceService = db.PriceService,
                DiscountsService = db.DiscountsService,
                SalesOrderRepository = db.SalesOrderRepository
            };

            var receipt = receiptFactory.GenerateFromSalesOrder(db.SalesOrderEntities[0]);


            //Act
            receipt.AddItem(db.Products["A2"]);


            //Assert
            Assert.Equal(55, receipt.Value);
        }

        [Fact]
        public void ShouldReturnPricingPlanForOnlyNewItemsInGenerateFromReceiptModeWhenSameProductsAdded()
        {
            //Arrange
            var db =
                TestDb.Add(
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

            var receiptFactory = new ReceiptFactory()
            {
                PriceService = db.PriceService,
                DiscountsService = db.DiscountsService,
                SalesOrderRepository = db.SalesOrderRepository
            };

            var receipt = receiptFactory.GenerateFromSalesOrder(db.SalesOrderEntities[0]);


            //Act
            receipt.AddItem(db.Products["A2"]);


            //Assert
            Assert.Equal(12, receipt.Value);
        }
    }
}
