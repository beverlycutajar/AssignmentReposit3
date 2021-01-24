﻿using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IProductsService
    {
        IQueryable<ProductViewModel> GetProducts(); //convert IQuesryable<product> to iqueryable<productViewmodel>

        ProductViewModel GetProduct(Guid id); // returns the details

        void AddProduct(ProductViewModel model);

        void DeleteProduct(Guid id);

        //IQueryable<ProductViewModel> GetProducts(int categoryId);

    }
}
