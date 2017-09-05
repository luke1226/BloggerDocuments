using System;

namespace BloggerDocuments.Tests.Db
{
    public class TestDbObjectList<TKey, TItem>
    {
        private readonly Func<TKey, TItem> _func;

        public TestDbObjectList(Func<TKey, TItem> func)
        {
            _func = func;
        }

        public TItem Get(TKey key)
        {
            return _func(key);
        }
    }
}