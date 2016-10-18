using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cash_Machine.Models
{
    public class Test
    {
        public Test()
        {
            Name = "Test";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ForeignTestId { get; set; }

        //[ForeignKey("ForeignTestId")]
        public ForeignTest ForeignTest { get; set; }
    }
}