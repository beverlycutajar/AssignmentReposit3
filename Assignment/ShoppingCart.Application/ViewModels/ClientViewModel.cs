using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class ClientViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage ="Kindly enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Kindly enter your surname")]
        public string LastName { get; set; }
    }
}
