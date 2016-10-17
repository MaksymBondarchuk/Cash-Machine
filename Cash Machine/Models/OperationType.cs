using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cash_Machine.Models
{
    public class OperationType
    {
        public OperationType()
        {
            CardOperation = new HashSet<CardOperation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CardOperation> CardOperation { get; set; }
    }
}