using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductIdFk { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
