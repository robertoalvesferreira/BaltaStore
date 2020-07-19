using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaltaStore.Infra.Model
{
    public class Order
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Customer Customer { get;  set; }
        [Required]
        public string Number { get;  set; }
        [Required]
        public DateTime CreateDate { get;  set; }
        [Required]
        public int Status { get;  set; }
    }
}
