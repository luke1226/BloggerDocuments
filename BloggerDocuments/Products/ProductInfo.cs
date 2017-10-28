using System.Diagnostics;

namespace BloggerDocuments.Products
{
    [DebuggerDisplay("Code = {" + nameof(Code) + "}")]
    public class ProductInfo
    {
        public int Id { get; }

        public string Code { get; }
   
        public ProductInfo(int id, string code)
        {
            Id = id;
            Code = code;
        }
    }
}