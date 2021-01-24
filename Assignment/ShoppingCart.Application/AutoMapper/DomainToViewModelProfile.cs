using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ShoppingCart.Application.AutoMapper
{
    public class DomainToViewModelProfile:Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>();  //product class models the db , PVM passes data to. from presentation layer
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
