using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cash_Machine.Models
{
    public class Card
    {
        public Card()
        {
            IsBlocked = false;
            Balance = 0.00m;
            CardOperation = new HashSet<CardOperation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool IsBlocked { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }

        public virtual ICollection<CardOperation> CardOperation { get; set; }
    }
}