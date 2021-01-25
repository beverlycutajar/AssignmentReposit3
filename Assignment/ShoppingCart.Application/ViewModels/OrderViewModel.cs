using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime DatePlaced { get; set; }

        [ForeignKey("Client")]
        public string Email { get; set; }
        public virtual Client Client { get; set; }
    }
}
