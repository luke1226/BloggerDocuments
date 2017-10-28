using BloggerDocuments.Database.Entities;

namespace BloggerDocuments.Database
{
    public interface IReceiptRepository
    {
        ReceiptEntity Get(int id);
    }
}
