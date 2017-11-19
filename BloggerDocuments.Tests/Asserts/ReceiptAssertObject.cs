using System.Linq;
using BloggerDocuments.Documents;
using Xunit;

namespace BloggerDocuments.Tests.Asserts
{
class ReceiptAssertObject
{
    private readonly Receipt _receipt;

    public ReceiptAssertObject(Receipt receipt)
    {
        _receipt = receipt;
    }

    public ReceiptAssertObject ValueEquals(decimal value, decimal netValue)
    {
        Assert.Equal(value, _receipt.Value);
        Assert.Equal(netValue, _receipt.NetValue);
        return this;
    }

        public ReceiptAssertObject ValueEquals(decimal value)
        {
            Assert.Equal(value, _receipt.Value);
            return this;
        }

        public ReceiptAssertObject ItemsCountEqual(int count)
        {
            Assert.Equal(count, _receipt.Items.Count);
            return this;
        }

        public ReceiptAssertObject HasItem(string name)
        {
            var item = _receipt.Items.FirstOrDefault(x => x.Name == name);

            Assert.NotNull(item);

            return this;
        }

        public ReceiptAssertObject HasNotItem(string name)
        {
            var item = _receipt.Items.FirstOrDefault(x => x.Name == name);
            Assert.Null(item);
            return this;
        }
    }
}
