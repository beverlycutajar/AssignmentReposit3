using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _categRepo;

        public CategoriesService( ICategoriesRepository categRepo)
        {
            _categRepo = categRepo;
        }

        public IQueryable<CategoryViewModel> GetCategories()
        {
            var list = from c in _categRepo.GetCategories()
                       select new CategoryViewModel()
                       {
                           Id = c.Id,
                           Name = c.Name
                       };
            return list;
        }
    }
}
