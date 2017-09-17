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
                    });

            var receiptFactory = new ReceiptFactory()
            {
                PriceService = db.PriceService,
                DiscountsService = db.DiscountsService
            };

            var receipt = receiptFactory.New();


            //Act
            receipt.AddItem(db.Products["A1"]);


            //Assert
            Assert.Equal(10, receipt.Value);
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

                        c.Documents.AddSalesOrder(
                            doc =>
                            {
                                doc.WithItems(
                                    itemsContext =>
                                    {
                                        itemsContext.Add("A1", 20, 1);
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
            receipt.AddItem(db.Products["A1"]);


            //Assert
            Assert.Equal(10, receipt.Value);
        }
    }
}
