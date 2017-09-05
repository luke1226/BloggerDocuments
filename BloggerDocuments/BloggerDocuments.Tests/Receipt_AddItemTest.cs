using BloggerDocuments.Tests.Db;
using BloggerDocuments.Tests.PriceCalculatorTests;
using Xunit;

namespace BloggerDocuments.Tests
{
    public class Receipt_AddItemTest
    {
        [Fact]
        public void ShouldReturnProperValue()
        {
            //Arrange
            var db = TestDb.Add(c => c.Products.Add("A1", p => p.WithPrice(5)));
            var receipt = new Receipt() { PriceCalculator = new PriceCalculatorMock(db.PriceService) };


            //Act
            receipt.AddItem(db.Products["A1"]);


            //Assert
            Assert.Equal(5m, receipt.Value);
        }
    }
}
