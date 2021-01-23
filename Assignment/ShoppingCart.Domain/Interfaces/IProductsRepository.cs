using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        Guid AddProduct(Product p);
        void DeleteProduct(Guid id);
        Product GetProduct(Guid id);

        //to implement a filtered search
        //IQueryable<Product> GetProducts(int category);

    }
}
