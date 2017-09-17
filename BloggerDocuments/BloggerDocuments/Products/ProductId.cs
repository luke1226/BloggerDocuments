namespace BloggerDocuments.Products
{
    public class ProductId
    {
        public string Value { get; }



        public ProductId(string code)
        {
            Value = code;
        }

        public ProductId(int id)
        {
            Value = id.ToString();
        }



        public override bool Equals(object obj)
        {
            return (obj as ProductId)?.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}