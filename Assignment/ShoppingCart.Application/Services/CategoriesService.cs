using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesService _categSer;

        public CategoriesService( ICategoriesService categSer)
        {
            _categSer = categSer;
        }

        public IQueryable<CategoryViewModel> GetCategories()
        {
            var list = from c in _categSer.GetCategories()
                       select new CategoryViewModel()
                       {
                           Id = c.Id,
                           Name = c.Name
                       };
            return list;
        }
    }
}
