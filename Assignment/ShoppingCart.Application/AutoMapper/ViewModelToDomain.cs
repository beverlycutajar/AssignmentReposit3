﻿using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class ViewModelToDomain:Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}