using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderDetailsViewModel
    {
      
        public int Id { get; set; }
        [ForeignKey("Product")]
        public Guid ProductFk { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Order")]
        public Guid OrderFk { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
