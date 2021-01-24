using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationApp.Models;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _prodService;
        private ICategoriesService _categoriesService;
        public ProductsController(IProductsService prodService, ICategoriesService categoriesService)
        {
            _prodService = prodService;
            _categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            var list = _prodService.GetProducts();
            return View(list);
        }

        [Authorize(Roles ="mgr")]
        public IActionResult Delete(Guid id)
        {
            _prodService.DeleteProduct(id);

            ViewData["feedback"] = "Product DELETED successfully"; // dont think li qed jehoda

            var list = _prodService.GetProducts();
            return RedirectToAction("Index",list);
        }

        public IActionResult Details (Guid id)
        {
            var p = _prodService.GetProduct(id);
            return View(p);
            //return View(_prodService.GetProduct(id));
        }

        [Authorize(Roles = "mgr")]
        [HttpGet]
        public IActionResult Create() //used to load the page with the empty textboxed to update the below method
        {
            var list = _categoriesService.GetCategories();

            CreateModel model = new CreateModel();
            
            model.Categories = list.ToList();

            return View(model);
        }
        
        [HttpPost]
        [Authorize(Roles = "mgr")]
        public IActionResult Create (CreateModel data) // this is triggered when the submit method is clicked
        {
            try
            {
                _prodService.AddProduct(data.Product);

                ViewData["feedback"] = "Product added successfully";
                ModelState.Clear(); //MHUX JEHODA #giveup
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Product was NOT ADDED. Please check your inputs";
            }

            var list = _categoriesService.GetCategories();
            data.Categories = list.ToList();
           
            return View(data);
        }

       // public IActionResult Search(int category) {
          //  var list = _prodService.GetProducts(category); 
         //   return RedirectToAction("Index" , list)
       // } //search by category
    }
}
