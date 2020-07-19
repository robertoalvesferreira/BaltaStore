using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaltaStore.Infra.Model
{
    public class Address
    {
        [Required]
        public Guid Id { get; set; }

        public Customer Customer { get; set; }
        

        [Required]
        [MaxLength(10)]
        public string Number { get; set; }

        [Required]
        [MaxLength(40)]
        public string Complement { get; set; }

        [Required]
        [MaxLength(40)]
        public string District { get; set; }

        [Required]
        [MaxLength(40)]
        public string City { get; set; }

        [Required]
        [MaxLength(40)]
        public long State { get; set; }

        [Required]
        [MaxLength(2)]
        public char Country { get; set; }


        [Required]
        [MaxLength(2)]
        public char ZipCode { get; set; }

        [Required]
        public int Type { get; set; }


    }
}
