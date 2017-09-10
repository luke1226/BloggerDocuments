using BloggerDocuments.Documents;

namespace BloggerDocuments.Factories
{
    public interface IReceiptFactory
    {
        Receipt New();

        Receipt Edit(int id);
    }
}