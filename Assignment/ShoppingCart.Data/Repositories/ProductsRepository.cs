﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class ProductsRepository : IProductsRepository //this class connects to the database, does an operation while managing the database data
                                                            //there are no validations or filtering here
    {
        ShoppingCartDbContext _context;
        public ProductsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public Guid AddProduct(Product p)
        {
           
            _context.Products.Add(p);
            _context.SaveChanges();

            return p.Id;
        }

        public void DeleteProduct(Guid id)
        {
            Product p = GetProduct(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category);
        }
    }
}
