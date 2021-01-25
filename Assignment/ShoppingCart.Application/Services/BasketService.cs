using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class BasketService : IBasketService
    {
        public void AddToCart(Guid id, int qty)
        {
            throw new NotImplementedException();
        }

        public void AddToCart(ProductViewModel v)
        {
            throw new NotImplementedException();
        }

        public void Checkout()
        {
            throw new NotImplementedException();
        }
    }
}
