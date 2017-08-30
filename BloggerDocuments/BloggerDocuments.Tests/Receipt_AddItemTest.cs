using BloggerDocuments.Tests.Db;
using Xunit;

namespace BloggerDocuments.Tests
{ 
public class Receipt_AddItemTest
{
    [Fact]
    public void ShouldReturnProperValue()
    {
        //Arrange
        var receipt = new Receipt() { PriceCalculator = new PriceCalculatorMock() };
        var product = TestDb.Products.Get("A1", p => p.WithPrice(5));


        //Act
        receipt.AddItem(product);
            

        //Assert
        Assert.Equal(5m, receipt.Value);
    }
}
}
