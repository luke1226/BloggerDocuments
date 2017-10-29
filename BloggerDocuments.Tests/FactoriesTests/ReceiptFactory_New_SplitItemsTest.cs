using BloggerDocuments.Tests.Environment;
using Xunit;

namespace BloggerDocuments.Tests.FactoriesTests
{
    public class ReceiptFactory_New_SplitItemsTest : TestClassBase
    {
        [Fact]
        public void ShouldSplitAndAddItemsOfBundleOnAddItem()
        {
            //Arrange
            var env =
                TestEnvironment.Create(
                    c =>
                    {
                        c.Products.AddOrUpdate("A1", p => p.WithPrice(10));
                        c.Products.AddOrUpdate("A2", p => p.WithPrice(5));

                        c.DiscountStructure.Add(d => d.AddProduct("A1", 1, 0.1m).AddProduct("A2", 1, 0.1m));
                    });

            var receiptFactory = env.DocumentFactories.ReceiptFactory();
            var receipt = receiptFactory.New();
            receipt.AddItem(env.Products.Get("A1"), 2);


            //Act
            receipt.AddItem(env.Products.Get("A2"));


            //Assert
            Assert.Equal(3, receipt.Items.Count);
        }
    }
}
