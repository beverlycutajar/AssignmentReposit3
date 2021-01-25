using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private IWebHostEnvironment _webHostingEnviornment;
        public ProductsController(IProductsService prodService, ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            _prodService = prodService;
            _categoriesService = categoriesService;
            _webHostingEnviornment = env;
        }
        public IActionResult Search(int category)
        {
            var list = _prodService.GetProductByCat(category);
            return View("Index", list);
        }
        /*public IActionResult AddToCart(Guid id)
        {

           // var list = _categoriesService.GetCategories();

            //CreateModel model = new CreateModel();

            //model.Categories = list.ToList();

            //return View(model);
        }*/
        public IActionResult Index()
        {
            try
            {
                var list = _prodService.GetProducts();
                return View(list);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
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

        [HttpGet]
        [Authorize(Roles ="mgr")]
        public IActionResult Create() //used to load the page with the empty textboxed to update the below method
        {
            var list = _categoriesService.GetCategories();

            CreateModel model = new CreateModel();
            
            model.Categories = list.ToList();

            return View(model);
        }
        
        [HttpPost]
        [Authorize(Roles ="mgr")]
        public IActionResult Create (CreateModel data) // this is triggered when the submit method is clicked
        {
            try
            {
                if (data.Product.Price != 0 && data.Product.Stock != 0 && data.Product.Name !=null)
                {
                    if (data.File != null)
                    {
                        if (data.File.Length > 0)
                        {
                            string newFileName = @"/images/" + Guid.NewGuid() + System.IO.Path.GetExtension(data.File.FileName);
                            string absPath = _webHostingEnviornment.WebRootPath;
                            using (var stream = System.IO.File.Create(absPath + newFileName))
                            {
                                data.File.CopyTo(stream);
                            }

                            data.Product.ImageURL = newFileName;
                        }
                    }

                    _prodService.AddProduct(data.Product);

                    ViewData["feedback"] = "Product added successfully";
                    ModelState.Clear(); //MHUX JEHODA #giveup
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Product was NOT ADDED. Please check your inputs";
            }

            var list = _categoriesService.GetCategories();
            data.Categories = list.ToList();
           
            return View(data);
        }
    }
}
