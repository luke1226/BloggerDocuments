using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.Objects
{
    class ElementInfoObjects
    {
        public ElementInfo Get(string name, decimal quantity = 1)
        {
            return new ElementInfo(new ProductId(name), quantity);
        }
    }
}
