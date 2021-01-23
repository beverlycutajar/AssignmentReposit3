using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _prodService;
       // private ICategoriesService _categoriesService;
        public ProductsController(IProductsService prodService)
        {
            _prodService = prodService;
        }
        public IActionResult Index()
        {
            var list = _prodService.GetProducts();
            return View(list);
        }

        public IActionResult Details (Guid id)
        {
            //  var p = _prodService.GetProduct(id);
            //return View(p);
            return View(_prodService.GetProduct(id));
        }

        [HttpGet]
        public IActionResult Create() //used to load the page with the empty textboxed to update the below method
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create (ProductViewModel data) // this is triggered when the submit method is clicked
        {
            try
            {

                _prodService.AddProduct(data);
                ViewData["feedback"] = "Product Added Successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Product was NOT ADDED. Please check your inputs";
            }

            return View();
        }
    }
}
