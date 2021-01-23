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

        public void AddProduct(ProductViewModel model)
        {
            Product p = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageId = model.ImageURL,
                Stock=model.Stock,
                CategoryId = model.Category.Id
            };  
            _productsRepository.AddProduct(p);
        }

        public ProductViewModel GetProduct(Guid id) //return details
        {
            var p = GetProducts().SingleOrDefault(x => x.Id == id);
            return p;
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
                           Stock=p.Stock,
                           Category = new CategoryViewModel(){ Id = p.Category.Id, Name = p.Category.Name }
                       };
            return list;
        }

       
    }
}
