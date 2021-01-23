using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
   public  class ProductViewModel //this view model shows what is accessible for the end user to see. 
        //this is also used not to return the whole class as it would pose a security risk since data cannot be controlled at the end user's side
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryViewModel Category { get; set; }
        public string ImageURL { get; set; }

        //public List<CategoryViewModel> Categories {get;set;}   LISTA TA KATEGORIJI
    }
}
