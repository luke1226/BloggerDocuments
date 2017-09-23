using System;
using System.Collections.Generic;
using Xunit;

namespace BloggerDocuments.Tests.Db
{
    public class TestDbObjectList<TKey, TItem>
    {
        private readonly Func<TKey, TItem> _func;
        private readonly Dictionary<TKey, TItem> _cache = new Dictionary<TKey, TItem>();

        public TestDbObjectList(Func<TKey, TItem> func)
        {
            _func = func;
        }

        public TItem Get(TKey key)
        {
            if (_cache.ContainsKey(key))
                return _cache[key];

            var item = _func(key);
            _cache.Add(key, item);
            return item;
        }
    }

    public class TestDbObjectListTest
    {
        [Fact]
        public void ShouldReturnSameInstanceOnSecondGetInvoke()
        {
            //Arrange
            var objectList = new TestDbObjectList<int, Guid>(x => Guid.NewGuid());

            var expectedGuid = objectList.Get(1);

            //Act
            var guid = objectList.Get(1);


            //Assert
            Assert.Equal(expectedGuid, guid);
        }
    }
}