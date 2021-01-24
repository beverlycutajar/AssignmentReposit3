using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Client
    {
        [Key]

        public string email{get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
