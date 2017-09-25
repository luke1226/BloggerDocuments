using BloggerDocuments.Factories;
using BloggerDocuments.Tests.Db;
using Xunit;

namespace BloggerDocuments.Tests.FactoriesTests
{
    public class ReceiptFactory_New_SplitItemsTest
    {
        [Fact]
        public void ShouldSplitAndAddItemsOfBundleOnAddItem()
        {
            //Arrange
            var db =
                TestDb.Add(
                    c =>
                    {
                        c.Products.Add("A1", p => p.WithPrice(10));
                        c.Products.Add("A2", p => p.WithPrice(5));

                        c.DiscountStructure.Add(d => d.AddProduct("A1", 1, 0.1m).AddProduct("A2", 1, 0.1m));
                    });

            var receiptFactory = new ReceiptFactory()
            {
                PriceService = db.PriceService,
                DiscountsService = db.DiscountsService,
                SalesOrderRepository = db.SalesOrderRepository
            };

            var receipt = receiptFactory.New();
            receipt.AddItem(db.Products["A1"], 2);


            //Act
            receipt.AddItem(db.Products["A2"]);


            //Assert
            Assert.Equal(3, receipt.Items.Count);
        }
    }
}
