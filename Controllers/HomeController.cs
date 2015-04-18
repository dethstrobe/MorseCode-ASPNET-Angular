using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using Microsoft.AspNet.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class HelloWorldController : Controller
    {
        //some simple examples I made while learning ASP.NET
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

}