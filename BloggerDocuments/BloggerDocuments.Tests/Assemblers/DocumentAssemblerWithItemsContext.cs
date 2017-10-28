using System.Collections.Generic;

namespace BloggerDocuments.Tests.Assemblers
{
    public class DocumentAssemblerWithItemsContext
    {
        public List<DocumentItemAssembler> DocumentItemAssemblers { get; set; }

        public DocumentAssemblerWithItemsContext()
        {
            DocumentItemAssemblers = new List<DocumentItemAssembler>();
        }

        public DocumentAssemblerWithItemsContext Add(string name, decimal price, decimal quantity)
        {
            var docItemAssembler = new DocumentItemAssembler();

            docItemAssembler
                .WithName(name)
                .WithPrice(price)
                .WithQuantity(quantity);

            DocumentItemAssemblers.Add(docItemAssembler);

            return this;
        }
    }
}