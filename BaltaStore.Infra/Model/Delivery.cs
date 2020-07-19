using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaltaStore.Infra.Model
{
    public class Delivery
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }
        [Required]
        public int Status { get; set; }
       
    }
}
