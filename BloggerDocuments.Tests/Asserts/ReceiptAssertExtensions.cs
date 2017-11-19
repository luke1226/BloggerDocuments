using BloggerDocuments.Documents;

namespace BloggerDocuments.Tests.Asserts
{
static class ReceiptAssertExtensions
{
    public static ReceiptAssertObject AssertThat(this Receipt receipt)
    {
        return new ReceiptAssertObject(receipt);
    }
}
}
