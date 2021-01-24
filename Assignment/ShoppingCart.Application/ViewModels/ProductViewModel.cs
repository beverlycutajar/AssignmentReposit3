using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
   public  class ProductViewModel //this view model shows what is accessible for the end user to see. 
        //this is also used not to return the whole class as it would pose a security risk since data cannot be controlled at the end user's side
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Please input the name of this product")]
        public string Name { get; set; }
        [StringLength(200, MinimumLength =15)]
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please enter the price")]
        [Range(1,1000)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public CategoryViewModel Category { get; set; }
       
        public string ImageURL { get; set; }
        [Range(1, 1000)]
        [Required(ErrorMessage = "Please enter the stock")]
        public int Stock { get; set; }

        //public List<CategoryViewModel> Categories {get;set;}   LISTA TA KATEGORIJI
    }
}
