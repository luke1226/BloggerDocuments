using System;
using System.Collections.Generic;

namespace BloggerDocuments.Tests.Assemblers
{
    class DocumentAssembler
    {
        public List<DocumentItemAssembler> DocumentItemAssemblers { get; }

        public DocumentAssembler()
        {
            DocumentItemAssemblers = new List<DocumentItemAssembler>();
        }

        public DocumentAssembler WithItems(Action<DocumentAssemblerWithItemsContext> withItemsContext)
        {
            var withItemsContextObj = new DocumentAssemblerWithItemsContext();
            withItemsContext(withItemsContextObj);
            DocumentItemAssemblers.AddRange(withItemsContextObj.DocumentItemAssemblers);
            return this;
        }
    }
}
