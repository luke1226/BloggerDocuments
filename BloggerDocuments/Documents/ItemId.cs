using System;

namespace BloggerDocuments.Documents
{
    public class ItemId
    {
        private readonly Guid _value;

        private ItemId()
        {
            _value = Guid.NewGuid();   
        }

        public static ItemId New()
        {
            return new ItemId();
        }

        public override bool Equals(object obj)
        {
            return (obj as ItemId)?._value == _value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(ItemId id1, ItemId id2)
        {
            return Equals(id1, id2);
        }

        public static bool operator !=(ItemId id1, ItemId id2)
        {
            return Equals(id1, id2);
        }
    }
}