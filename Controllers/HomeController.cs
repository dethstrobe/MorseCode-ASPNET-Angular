using System;
//using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }

    public class HelloWorldController : Controller
    {
        //
        //GET: /HelloWorld/

        public string Index()
        {
            return "This is my <strong>default</strong> action...";
        }

        //
        //GET: /HelloWorld/Welcome
        public string Welcome(string name, int numTimes = 1)
        {
            return ("Hello "+ name + ", Number of Times is "+numTimes);
        }
    }

    public class MorseCodeController : Controller
    {
        public string Index ()
        {
            return "Testing Morse Code";
        }
    }
}