using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationApp.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost] //recieve data from a form submission
        public ActionResult Contact(string email, string query)
        {

            if (string.IsNullOrEmpty(query))
            {
                ViewData["error"] = "One of the inputs is left empty";
            }
            else ViewData["feedback"] = "Thank you for your query. We will be with you shortly";

            return View();
        }
    }
}
