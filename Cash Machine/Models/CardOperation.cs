using System;
using System.Diagnostics.CodeAnalysis;

namespace Cash_Machine.Models
{
    public class CardOperation
    {
        public CardOperation()
        {
            Amount = 0.00m;
        }

        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public Guid OperationTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Balance { get; set; }

        public virtual Card Card { get; set; }
        public virtual OperationType OperationType { get; set; }
    }
}