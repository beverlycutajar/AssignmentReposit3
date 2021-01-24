using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private IMapper _mapper;

       public  ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public void AddProduct(ProductViewModel model)
        {
          _productsRepository.AddProduct(_mapper.Map<Product>(model));
        }

        public void DeleteProduct(Guid id)
        {
            _productsRepository.DeleteProduct(id);
            
        }

        public ProductViewModel GetProduct(Guid id) //return details
        {
            var p = GetProducts().SingleOrDefault(x => x.Id == id);
            if (p == null) return null;
            return (_mapper.Map<ProductViewModel>(p));
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
            //var a = _productsRepository.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            //return a; THIS IS BREAKING THE IMAGES 
        }

       
    }
}
