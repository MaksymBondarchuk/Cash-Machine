using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cash_Machine.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsBlocked { get; set; }

        public decimal Balance { get; set; }

        public string Password { get; set; }

        public string Number { get; set; }
    }
}