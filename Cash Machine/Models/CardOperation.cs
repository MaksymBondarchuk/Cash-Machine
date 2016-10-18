using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cash_Machine.Models
{
    public class CardOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CardId { get; set; }

        public Guid OperationTypeId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public decimal Balance { get; set; }


        public Card Card { get; set; }
        public OperationType OperationType { get; set; }
    }
}