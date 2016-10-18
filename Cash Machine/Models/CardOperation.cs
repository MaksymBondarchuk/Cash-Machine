using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Cash_Machine.Models
{
    public class CardOperation
    {
        public CardOperation()
        {
            Id = new Guid();
            Amount = 0.00m;
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public Guid OperationTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Balance { get; set; }

        public virtual Card Card { get; set; }
        //public virtual OperationType OperationType { get; set; }
    }
}