using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {

        public static void RegisterServices(IServiceCollection services, string ConnectionString) // with every new interface, because of DI .. we need to 
                                                                                //put an association with theis services collection
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
            options.UseSqlServer(
                ConnectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();
        }
    }
}
