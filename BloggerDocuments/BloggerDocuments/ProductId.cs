using System;

namespace BloggerDocuments
{
    public class ProductId
    {
        private readonly string _code;

        public string Value { get; }



        public ProductId()
        {
            Value = Guid.NewGuid().ToString();;
            _code = Value.ToString();
        }

        public ProductId(string code)
        {
            Value = code.ToString();
            _code = code;
        }



        public override bool Equals(object obj)
        {
            return (obj as ProductId)?._code == _code;
        }

        public override int GetHashCode()
        {
            return _code.GetHashCode();
        }
    }
}