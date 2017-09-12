using System;

namespace BloggerDocuments.Products
{
    public class ProductId
    {
        private readonly string _code;

        public string Value { get; }



        public ProductId()
        {
            Value = Guid.NewGuid().ToString();;
            _code = Value;
        }

        public ProductId(string code)
        {
            Value = code;
            _code = code;
        }

        public ProductId(int id)
        {
            Value = id.ToString();
            _code = Value;
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