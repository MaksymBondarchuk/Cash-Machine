using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cash_Machine.Models
{
    public class ForeignTest
    {
        public ForeignTest()
        {
            Name = "Test1";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}