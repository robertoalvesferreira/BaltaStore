using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace BaltaStore.Infra.Model
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Description { get; private set; }
        [Required]
        public string Image { get; private set; }
        [Required]
        public decimal Price { get; private set; }
        [Required]
        public decimal QuantityOnHand { get; private set; }
    }
}
