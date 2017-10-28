using BloggerDocuments.Database.Entities;

namespace BloggerDocuments.Database
{
    public interface ISalesOrderRepository
    {
        SalesOrderEntity Get(int id);
    }
}