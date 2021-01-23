using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsService
    {

        private IProductsRepository _productsRepository;

       public  ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
    
        public IQueryable<ProductViewModel> GetProducts()//convert IQuesryable<product> to iqueryable<productViewmodel>
        {
            var list = from p in _productsRepository.GetProducts()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           ImageURL = p.ImageId,
                           Description = p.Description,
                           Price = p.Price,
                           Category = new CategoryViewModel(){ Id = p.Category.Id, Name = p.Category.Name }
                       };
            return list;
        }

       
    }
}
